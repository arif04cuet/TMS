﻿using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class BatchScheduleAllocationService : IBatchScheduleAllocationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IExcelService _excelService;
        private readonly IAllocationService _allocationService;
        private readonly IRepository<BatchScheduleAllocation> _batchSceduleAllocationRepository;
        private readonly ILogger<BatchScheduleAllocationService> _logger;

        public BatchScheduleAllocationService(
            IUnitOfWork unitOfWork,
            IExcelService excelService,
            IAllocationService allocationService,
            ILogger<BatchScheduleAllocationService> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _excelService = excelService;
            _allocationService = allocationService;
            _batchSceduleAllocationRepository = _unitOfWork.GetRepository<BatchScheduleAllocation>();
        }

        public async Task<long> CreateAsync(BatchScheduleAllocationCreateRequest request, CancellationToken cancellationToken = default)
        {

            if (request.Bed.HasValue && request.Room.HasValue)
                throw new ValidationException("Allocation can not have both bed and room.");

            var entity = request.Map();
            await _batchSceduleAllocationRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (request.Bed.HasValue || request.Room.HasValue)
            {
                // temporary booked hostel allocation
                var hostelAllocation = new Allocation
                {
                    CheckinDate = DateTime.UtcNow,
                    BatchScheduleAllocationId = entity.Id,
                    Status = AllocationStatus.TemporaryBooked,
                    UserId = entity.TraineeId
                };
                await _allocationService.UpdateBedOrRoom(hostelAllocation, request.Bed, request.Room);
                await _unitOfWork.GetRepository<Allocation>().AddAsync(hostelAllocation);
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(BatchScheduleAllocationUpdateRequest request, CancellationToken cancellationToken = default)
        {

            if (request.Bed.HasValue && request.Room.HasValue)
                throw new ValidationException("Allocation can not have both bed and room.");

            var entity = await _batchSceduleAllocationRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Allocation not found");

            Bed oldBed = await _unitOfWork.GetRepository<Bed>()
                .FirstOrDefaultAsync(x => x.Id == entity.BedId && !x.IsDeleted);

            request.Map(entity);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            // update hostel allocation
            var hostelAllocation = await _unitOfWork.GetRepository<Allocation>()
                .FirstOrDefaultAsync(x => x.BatchScheduleAllocationId == entity.Id && !x.IsDeleted);

            if (hostelAllocation != null)
            {
                await _allocationService.UpdateBedOrRoom(hostelAllocation, request.Bed, request.Room);
            }
            if (oldBed != null && oldBed.Id != request.Bed)
            {
                oldBed.IsBooked = false;
            }
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> UpdateStatusAsync(BatchScheduleAllocationUpdateStatusRequest request, CancellationToken cancellationToken = default)
        {
            if (request.Ids.Length > 0)
            {
                var allocations = await _batchSceduleAllocationRepository
                    .AsQueryable()
                    .Include(x => x.BatchSchedule)
                    .Where(x => request.Ids.Contains(x.Id) && !x.IsDeleted)
                    .ToListAsync();

                foreach (var allocation in allocations)
                {
                    if (request.Status == (long)BatchScheduleAllocationStatus.Approved)
                    {
                        var totalApproved = await _batchSceduleAllocationRepository
                            .AsReadOnly()
                            .CountAsync(x => x.BatchScheduleId == allocation.BatchScheduleId
                            && x.Status == BatchScheduleAllocationStatus.Approved
                            && !x.IsDeleted);
                        if (allocation.BatchSchedule.TotalSeat > totalApproved)
                        {
                            allocation.Status = (BatchScheduleAllocationStatus)request.Status;

                            // booked hostel allocation
                            var hostelAllocation = await _unitOfWork.GetRepository<Allocation>()
                                .FirstOrDefaultAsync(x => x.BatchScheduleAllocationId == allocation.Id && !x.IsDeleted);
                            if (hostelAllocation != null)
                            {
                                hostelAllocation.Status = AllocationStatus.Booked;
                            }
                        }
                        else
                        {
                            _logger.LogInformation($"Batch allocation({allocation.Id}) can be approved because batch schedule reached the max seat qouta.");
                        }
                    }
                    else
                    {
                        allocation.Status = (BatchScheduleAllocationStatus)request.Status;
                    }
                }
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
                return result > 0;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _batchSceduleAllocationRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Batch allocation not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<BatchScheduleAllocationViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _batchSceduleAllocationRepository.GetAsync(x => x.Id == id, BatchScheduleAllocationViewModel.Select(), cancellationToken);

            return item;
        }

        public async Task<PagedCollection<BatchScheduleAllocationViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _batchSceduleAllocationRepository.ListAsync(BatchScheduleAllocationViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<byte[]> ExportAllocationAsync(ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _batchSceduleAllocationRepository
                .AsQueryable()
                .ApplySearch(searchOptions)
                .Select(BatchScheduleAllocationExcelModel.Select())
                .ToListAsync();

            var bytes = _excelService.Generate(result);
            return bytes;
        }

    }
}
