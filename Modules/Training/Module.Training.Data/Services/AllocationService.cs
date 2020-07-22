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
using Module.Core.Shared;
using Infrastructure.Services;
using Module.Core.Entities;

namespace Module.Training.Data
{
    public class AllocationService : IAllocationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Allocation> _allocationRepository;
        private readonly IEmailSender _emailSender;

        public AllocationService(
            IUnitOfWork unitOfWork,
            IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _allocationRepository = _unitOfWork.GetRepository<Allocation>();
            _emailSender = emailSender;
        }

        public async Task<long> CreateAsync(AllocationCreateRequest request, CancellationToken cancellationToken = default)
        {
            if (!request.Bed.HasValue && !request.Room.HasValue)
                throw new ValidationException("Room or bed required.");

            if (request.Bed.HasValue && request.Room.HasValue)
                throw new ValidationException("Room and bed can not be choose at the same time.");

            if (request.Status == AllocationStatus.Cancelled)
                throw new ValidationException("Can not allocate for cancel.");

            var allocation = new Allocation
            {
                UserId = request.Participant,
                CheckinDate = request.CheckinDate,
                Status = request.Status
            };

            await UpdateBedOrRoom(allocation, request.Bed, request.Room);
            await _allocationRepository.AddAsync(allocation, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return allocation.Id;
        }

        public async Task<long> UpdateAsync(AllocationUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var allocation = await _allocationRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (allocation == null)
                throw new ValidationException("Allocation not found");

            await UpdateBedOrRoom(allocation, request.Bed, request.Room);

            allocation.UserId = request.Participant;
            allocation.CheckinDate = request.CheckinDate;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return allocation.Id;
        }

        public async Task<long> CheckoutAsync(AllocationUpdateRequest request, CancellationToken cancellationToken = default)
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

            if (allocation.BedId.HasValue)
                allocation.Bed.IsBooked = false;

            if (allocation.RoomId.HasValue)
                allocation.Room.IsBooked = false;

            allocation.Status = AllocationStatus.CheckedOut;
            allocation.Amount = request.Amount;
            allocation.Days = request.Days;
            allocation.CheckoutDate = request.CheckoutDate;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return allocation.Id;
        }

        public async Task<long> CancelAsync(long allocationId, CancellationToken cancellationToken = default)
        {
            var allocation = await _allocationRepository.FirstOrDefaultAsync(x => x.Id == allocationId && !x.IsDeleted);

            if (allocation == null)
                throw new ValidationException("Allocation not found");

            Bed bed = await _unitOfWork.GetRepository<Bed>().FirstOrDefaultAsync(x => x.Id == allocation.BedId && !x.IsDeleted);

            Room room = await _unitOfWork.GetRepository<Room>().FirstOrDefaultAsync(x => x.Id == allocation.RoomId && !x.IsDeleted);

            if (bed != null)
            {
                bed.IsBooked = false;
            }

            if (room != null)
            {
                room.IsBooked = false;
            }

            allocation.Status = AllocationStatus.Cancelled;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                var user = await _unitOfWork.GetRepository<User>().FirstOrDefaultAsync(x => x.Id == allocation.UserId && !x.IsDeleted);
                if (user != null)
                {
                    string subject = $"Allocation({allocation.Id}) has been cancelled.";
                    string text = $"Dear {user.FullName}\n\nYour allocation has been cancelled.";
                    _ = _emailSender.SendAsync(user.Email, subject, text);
                }
            }

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

        public async Task<AllocationRentViewModel> GetRent(long allocationId, DateTime checkout, CancellationToken cancellationToken = default)
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
                .FirstOrDefaultAsync(x => x.Id == allocationId && !x.IsDeleted, cancellationToken);

            if (item == null)
                throw new ValidationException("Allocation not found.");

            if (!item.CheckinDate.HasValue || checkout == default)
                throw new ValidationException("Invalid checkin or checkout date.");

            var days = (long)(checkout - item.CheckinDate).Value.TotalDays;
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

                amount = Math.Floor((bed.RoomRent / bed.BedCount) * days);

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

        public async Task<PagedCollection<IdNameViewModel>> ListBatchScheduleAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _allocationRepository
                .Paginate<Allocation, IdNameViewModel>(pagingOptions, searchOptions)
                .Where(x => x.BatchScheduleAllocationId.HasValue && (x.Status == AllocationStatus.TemporaryBooked || x.Status == AllocationStatus.Booked))
                .Select(x => new IdNameViewModel
                {
                    Id = x.BatchScheduleAllocation.BatchScheduleId,
                    Name = x.BatchScheduleAllocation.BatchSchedule.Name
                })
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<long> GroupCheckoutByBatchScheduleAsync(AllocationGroupCheckoutByBatchScheduleRequest request, CancellationToken cancellationToken = default)
        {
            var allocations = await _allocationRepository
                .AsQueryable()
                .Include(x => x.Bed)
                .Include(x => x.Room)
                .Where(x => x.BatchScheduleAllocation.BatchScheduleId == request.BatchSchedule
                && x.Status != AllocationStatus.CheckedOut && !x.IsDeleted)
                .ToListAsync();

            int result = 0;
            foreach (var allocation in allocations)
            {
                var checkoutDate = DateTime.UtcNow;
                var rent = await GetRent(allocation.Id, checkoutDate);

                if (allocation.BedId.HasValue)
                    allocation.Bed.IsBooked = false;

                if (allocation.RoomId.HasValue)
                    allocation.Room.IsBooked = false;

                allocation.Status = AllocationStatus.CheckedOut;
                allocation.Amount = rent.Amount;
                allocation.Days = (int)rent.Days;
                allocation.CheckoutDate = checkoutDate;

                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            return result;
        }

        public async Task UpdateBedOrRoom(Allocation a, long? bed, long? room, bool validation = true)
        {
            if (bed.HasValue && room.HasValue)
                throw new ValidationException("Can not have both bed and room at the same time.");

            Bed newBed = await _unitOfWork.GetRepository<Bed>().FirstOrDefaultAsync(x => x.Id == bed && !x.IsBooked && !x.IsDeleted);

            if (validation && bed.HasValue && newBed == null)
                throw new ValidationException("Bed is not allowed for allocaion");

            Room newRoom = await _unitOfWork.GetRepository<Room>().FirstOrDefaultAsync(x => x.Id == room && !x.IsBooked && !x.IsDeleted);

            if (validation && room.HasValue && newRoom == null)
                throw new ValidationException("Room is not allowed for allocaion");

            Bed oldBed = await _unitOfWork.GetRepository<Bed>()
                    .FirstOrDefaultAsync(x => x.Id == a.BedId && !x.IsDeleted);

            Room oldRoom = await _unitOfWork.GetRepository<Room>()
                            .FirstOrDefaultAsync(x => x.Id == a.RoomId && !x.IsDeleted);

            if (newBed != null)
            {
                a.HostelId = newBed.HostelId;
                a.BuildingId = newBed.BuildingId;
                a.FloorId = newBed.FloorId;
                a.BedId = newBed.Id;
                a.RoomId = null;
                newBed.IsBooked = true;
            }

            if (newRoom != null)
            {
                a.HostelId = newRoom.HostelId;
                a.BuildingId = newRoom.BuildingId;
                a.FloorId = newRoom.FloorId;
                a.RoomId = newRoom.Id;
                a.BedId = null;
                newRoom.IsBooked = true;
            }

            if (oldRoom != null)
                oldRoom.IsBooked = false;

            if (oldBed != null)
                oldBed.IsBooked = false;
        }

    }
}
