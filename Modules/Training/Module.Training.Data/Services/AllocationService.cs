using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class AllocationService : IAllocationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Allocation> _allocationRepository;

        public AllocationService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _allocationRepository = _unitOfWork.GetRepository<Allocation>();
        }

        public async Task<long> CreateAsync(AllocationCreateRequest request, CancellationToken cancellationToken = default)
        {

            if(request.Bed.HasValue && request.Room.HasValue)
                throw new ValidationException("Choose bed or room at a time.");

            long? bedId = null;
            long? roomId = null;
            long buildingId = 0;
            long hostelId = 0;
            long floorId = 0;
            if (request.Bed.HasValue)
            {
                var bed = await _unitOfWork.GetRepository<Bed>().FirstOrDefaultAsync(x => x.Id == request.Bed && !x.IsBooked && !x.IsDeleted);

                if (bed == null)
                    throw new ValidationException("Bed is allowed to allocaion");

                bedId = bed.Id;
                hostelId = bed.HostelId;
                buildingId = bed.BuildingId;
                floorId = bed.FloorId;
            }

            if(request.Room.HasValue)
            {
                var room = await _unitOfWork.GetRepository<Room>().FirstOrDefaultAsync(x => x.Id == request.Room && !x.IsBooked && !x.IsDeleted);

                if (room == null)
                    throw new ValidationException("Room is allowed to allocaion");

                roomId = room.Id;
                hostelId = room.HostelId;
                buildingId = room.BuildingId;
                floorId = room.FloorId;
            }

            var allocation = new Allocation
            {
                BedId = bedId,
                RoomId = roomId,
                BuildingId = buildingId,
                HostelId = hostelId,
                FloorId = floorId
            };
            await _allocationRepository.AddAsync(allocation, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return allocation.Id;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _allocationRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Allocation not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<AllocationViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _allocationRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new AllocationViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    Bed = IdNameViewModel.Map(x.Bed),
                    CheckinDate = x.CheckinDate,
                    CheckoutDate = x.CheckoutDate,
                    Days = x.Days,
                    Room = IdNameViewModel.Map(x.Room),
                    User = new IdNameViewModel { Id = x.User.Id, Name = x.User.FullName }
                })
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Allocation not found");

            return item;
        }

        public async Task<PagedCollection<AllocationViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var hostels = _allocationRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = hostels.Select(x => new AllocationViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Bed = IdNameViewModel.Map(x.Bed),
                CheckinDate = x.CheckinDate,
                CheckoutDate = x.CheckoutDate,
                Days = x.Days,
                Room = IdNameViewModel.Map(x.Room),
                User = new IdNameViewModel { Id = x.User.Id, Name = x.User.FullName }
            });

            var total = await hostels.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<AllocationViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
