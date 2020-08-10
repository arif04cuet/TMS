using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
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
        private readonly IRazorViewRenderer _viewRenderer;
        private readonly IPdfConverter _pdfConverter;

        public BatchScheduleAllocationService(
            IUnitOfWork unitOfWork,
            IExcelService excelService,
            IAllocationService allocationService,
            ILogger<BatchScheduleAllocationService> logger,
            IPdfConverter pdfConverter,
            IRazorViewRenderer viewRenderer)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _excelService = excelService;
            _allocationService = allocationService;
            _pdfConverter = pdfConverter;
            _viewRenderer = viewRenderer;
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
                    //CheckinDate = DateTime.UtcNow,
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

                int result = 0;
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
                            throw new ValidationException($"Can not be approved because batch schedule reached the maximum seat qouta.");
                        }
                    }
                    else
                    {
                        allocation.Status = (BatchScheduleAllocationStatus)request.Status;
                    }
                    result += await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                return result > 0;
            }
            return false;
        }

        public async Task<bool> MigrateToNextBatchAsync(MigrateToNextBatchRequest request, CancellationToken cancellationToken = default)
        {
            if (request.Ids.Length > 0)
            {
                var allocations = await _batchSceduleAllocationRepository
                    .AsQueryable()
                    .Include(x => x.BatchSchedule)
                    .Where(x => request.Ids.Contains(x.Id) && !x.IsDeleted)
                    .ToListAsync();

                int result = 0;
                foreach (var allocation in allocations)
                {
                    // find batch schedule's of course schedule
                    var nextBatchSchedule = await _unitOfWork.GetRepository<BatchSchedule>()
                        .Where(x => x.CourseScheduleId == allocation.BatchSchedule.CourseScheduleId
                        && x.Id != allocation.BatchScheduleId
                        && x.StartDate > allocation.BatchSchedule.StartDate
                        && !x.IsDeleted)
                        .OrderBy(x => x.StartDate)
                        .FirstOrDefaultAsync(cancellationToken);

                    if (nextBatchSchedule == null)
                        throw new ValidationException("Next batch not found.");

                    allocation.Status = BatchScheduleAllocationStatus.Waiting;
                    allocation.BatchScheduleId = nextBatchSchedule.Id;
                    result += await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
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

        public async Task<byte[]> DownloadCertificateAsync(long batchScheduleAllocationId, CancellationToken cancellationToken = default)
        {
            var model = await _unitOfWork.GetRepository<BatchScheduleAllocation>()
                .AsReadOnly()
                .Where(x => x.Id == batchScheduleAllocationId && !x.IsDeleted)
                .Select(x => new ParticipantCertificatePdfModel
                {
                    ParticipantName = x.Trainee.FullName,
                    CourseName = x.BatchSchedule.CourseSchedule.Course.Name,
                    CourseDate = $"{x.BatchSchedule.StartDate.Date} - {x.BatchSchedule.EndDate.Date}",
                    Serial = "123"
                })
                .FirstOrDefaultAsync();

            var serial = 0;
            if (model != null)
            {
                serial = await _unitOfWork.GetRepository<Certificate>()
                    .AsReadOnly()
                    .Where(x => !x.IsDeleted)
                    .CountAsync();

                model.Serial = (serial + 1).ToString();

                await _unitOfWork.GetRepository<Certificate>().AddAsync(new Certificate
                {
                    Serial = model.Serial,
                    BatchScheduleAllocationId = batchScheduleAllocationId
                });
                await _unitOfWork.SaveChangesAsync();
            }

            var htmlContent = await _viewRenderer.RenderViewToStringAsync("/Views/certificate.cshtml", model);
            var pdfBytes = _pdfConverter.Convert(htmlContent);
            return pdfBytes;
        }

    }
}
