using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Shared;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class HostelService : IHostelService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Hostel> _hostelRepository;
        private readonly IRepository<Floor> _floorRepository;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<Building> _buildingRepository;
        private readonly IRepository<Bed> _bedRepository;

        public HostelService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _hostelRepository = _unitOfWork.GetRepository<Hostel>();
            _floorRepository = _unitOfWork.GetRepository<Floor>();
            _roomRepository = _unitOfWork.GetRepository<Room>();
            _buildingRepository = _unitOfWork.GetRepository<Building>();
            _bedRepository = _unitOfWork.GetRepository<Bed>();
        }

        public async Task<long> CreateAsync(HostelCreateRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CreateAsync(request.Map(), cancellationToken);
            return result;
        }

        public async Task<bool> UpdateAsync(HostelUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _hostelRepository
                .AsQueryable()
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Hostel not found");

            entity.Name = request.Name;
            entity.Address.AddressLine1 = request.Address;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.DeleteAsync<Hostel>(id, cancellationToken);
            return result;
        }

        public async Task<HostelViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _hostelRepository.GetAsync(x => x.Id == id, HostelViewModel.Select(), cancellationToken);

            return item;
        }

        public async Task<PagedCollection<HostelViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _hostelRepository
                .ListAsync(null, HostelViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> ListBuildingsAsync(long hostelId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _buildingRepository.ListAsync(x => x.HostelId == hostelId, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> ListFloorsAsync(long hostelId, long buildingId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _floorRepository.ListAsync(x => x.HostelId == hostelId && x.BuildingId == buildingId, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> ListRoomsAsync(long hostelId, long buildingId, long floorId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _roomRepository.ListAsync(x => x.HostelId == hostelId && x.BuildingId == buildingId && x.FloorId == floorId, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> ListBedsAsync(long hostelId, long buildingId, long floorId, long roomId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _bedRepository.ListAsync(x => x.HostelId == hostelId && x.BuildingId == buildingId && x.FloorId == floorId && x.RoomId == roomId, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<HotelAndRoomViewModel>> ListRoomsAndBedsAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _roomRepository.ListAsync(x => !x.IsBooked,
                x => new HotelAndRoomViewModel
                {
                    Name = x.Name,
                    Type = x.Type.Name,
                    BedCount = x.Beds.Where(y => !y.IsBooked && !y.IsDeleted).Count()
                }, pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<HostelDashboardViewModel> GetDashboard(CancellationToken cancellationToken = default)
        {
            HostelDashboardViewModel model = new HostelDashboardViewModel();

            model.TotalRoom = await _unitOfWork.GetRepository<Room>().Where(x => !x.IsDeleted).LongCountAsync();
            model.FreeRoom = await _unitOfWork.GetRepository<Room>().Where(x => !x.IsBooked && !x.IsDeleted).LongCountAsync();

            model.TotalSeat = await _unitOfWork.GetRepository<Bed>().Where(x => !x.IsDeleted).LongCountAsync();
            model.FreeSeat = await _unitOfWork.GetRepository<Bed>().Where(x => !x.IsBooked && !x.IsDeleted).LongCountAsync();

            model.TodaysCheckin = await _unitOfWork.GetRepository<Allocation>()
                .Where(x => x.CheckinDate.Value.Date == DateTime.UtcNow.Date
                && x.Status == AllocationStatus.Booked
                && !x.IsDeleted)
                .LongCountAsync();

            model.TodaysCheckout = await _unitOfWork.GetRepository<Allocation>()
                .Where(x => x.CheckoutDate.Value.Date == DateTime.UtcNow.Date
                && x.Status == AllocationStatus.CheckedOut
                && !x.IsDeleted)
                .LongCountAsync();

            model.TodaysCheckoutable = 0;

            model.AllocatedRoom = await _unitOfWork.GetRepository<Room>().Where(x => x.IsBooked && !x.IsDeleted).LongCountAsync();

            model.AllocatedSeat = await _unitOfWork.GetRepository<Bed>().Where(x => x.IsBooked && !x.IsDeleted).LongCountAsync();

            model.BookingRequest = await _unitOfWork.GetRepository<Allocation>().Where(x => x.Status == AllocationStatus.TemporaryBooked && !x.IsDeleted).LongCountAsync();

            model.CheckinAndCheckout = await _unitOfWork.GetRepository<Allocation>().Where(x => (x.Status == AllocationStatus.Booked || x.Status == AllocationStatus.CheckedOut) && !x.IsDeleted).LongCountAsync();

            model.RequiredRoomAndSeat = 0;

            return model;
        }
    }
}
