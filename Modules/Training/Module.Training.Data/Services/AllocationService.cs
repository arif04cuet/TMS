using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;
using Module.Core.Data;
using System;
using System.Linq;

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

            if (!request.Bed.HasValue && !request.Room.HasValue)
                throw new ValidationException("Room or bed required.");

            if (request.Bed.HasValue && request.Room.HasValue)
                throw new ValidationException("Room and bed can be choose at the same time.");

            if (request.Status == AllocationStatus.Cancelled)
                throw new ValidationException("Can not allocate for cancel.");

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

                bed.IsBooked = true;
            }

            if (request.Room.HasValue)
            {
                var room = await _unitOfWork.GetRepository<Room>().FirstOrDefaultAsync(x => x.Id == request.Room && !x.IsBooked && !x.IsDeleted);

                if (room == null)
                    throw new ValidationException("Room is allowed to allocaion");

                roomId = room.Id;
                hostelId = room.HostelId;
                buildingId = room.BuildingId;
                floorId = room.FloorId;

                room.IsBooked = true;
            }

            var allocation = new Allocation
            {
                BedId = bedId,
                RoomId = roomId,
                BuildingId = buildingId,
                HostelId = hostelId,
                FloorId = floorId,
                UserId = request.Participant,
                CheckinDate = request.CheckinDate,
                Status = request.Status
            };
            await _allocationRepository.AddAsync(allocation, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return allocation.Id;
        }

        public async Task<long> UpdateAsync(AllocationUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var allocation = await _allocationRepository
                .AsQueryable()
                .Include(x => x.Bed)
                .Include(x => x.Room)
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (allocation == null)
                throw new ValidationException("Allocation not found");

            if (allocation.BedId != null && allocation.RoomId != null)
                throw new ValidationException("Allocation can not have both bed and room");

            if (request.Status == AllocationStatus.Booked && allocation.Status != AllocationStatus.TemporaryBooked)
                throw new ValidationException($"{AllocationStatus.TemporaryBooked.ToString()} allocation can be changed as {AllocationStatus.Booked.ToString()}.");

            if (request.Status == AllocationStatus.TemporaryBooked)
                throw new ValidationException($"Allocation can not be converted to {AllocationStatus.TemporaryBooked.ToString()}.");

            if (allocation.BedId.HasValue)
                allocation.Bed.IsBooked = false;

            if (allocation.RoomId.HasValue)
                allocation.Room.IsBooked = false;

            allocation.Status = AllocationStatus.CheckedOut;

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
            var item = await _allocationRepository.GetAsync(x => x.Id == id, AllocationViewModel.Select());
            return item;
        }

        public async Task<AllocationRentViewModel> GetRent(long id, DateTime checkout, CancellationToken cancellationToken = default)
        {
            var item = await _allocationRepository
                .AsReadOnly()
                .Include(x => x.Room).ThenInclude(x => x.Type)
                .Select(x => new
                {
                    Id = x.Id,
                    IsDeleted = x.IsDeleted,
                    CheckinDate = x.CheckinDate,
                    RoomId = x.RoomId,
                    BedId = x.BedId,
                    HostelId = x.HostelId,
                    BuildingId = x.BuildingId
                })
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);

            if (item == null)
                throw new ValidationException("Allocation not found.");

            if (!item.CheckinDate.HasValue || checkout == default)
                throw new ValidationException("Invalid checkin or checkout date.");

            var days = (checkout - item.CheckinDate).Value.TotalDays;
            double amount = 0;

            if (item.RoomId.HasValue)
            {
                var rent = await _unitOfWork.GetRepository<Room>()
                     .AsReadOnly()
                     .Where(x => x.Id == item.RoomId && !x.IsDeleted)
                     .Select(x => x.Type.Rent)
                     .FirstOrDefaultAsync(cancellationToken);

                amount = rent * days;
            }
            else if (item.BedId.HasValue)
            {
                var bed = await _unitOfWork.GetRepository<Bed>()
                    .AsReadOnly()
                    .Include(x => x.Room).ThenInclude(x => x.Type)
                    .Include(x => x.Room).ThenInclude(x => x.Beds)
                    .Where(x => x.Id == item.BedId && x.HostelId == item.HostelId && x.BuildingId == item.BuildingId && !x.IsDeleted)
                    .Select(x => new
                    {
                        BedCount = x.Room.Beds.Count(),
                        RoomRent = x.Room.Type.Rent
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if (bed == null)
                    throw new ValidationException("Bed not not found.");

                amount = (bed.RoomRent / bed.BedCount) * days;

            }

            return new AllocationRentViewModel
            {
                Amount = amount,
                Days = days
            };
        }

        public async Task<PagedCollection<AllocationViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _allocationRepository.ListAsync(AllocationViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

    }
}
