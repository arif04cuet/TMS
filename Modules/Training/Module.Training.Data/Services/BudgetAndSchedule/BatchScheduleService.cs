using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Shared;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class BatchScheduleService : IBatchScheduleService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<BatchSchedule> _batchScheduleRepository;
        private readonly IRepository<BatchScheduleAllocation> _batchScheduleAllocationRepository;
        private readonly IRazorViewRenderer _viewRenderer;
        private readonly IPdfConverter _pdfConverter;

        public BatchScheduleService(
            IUnitOfWork unitOfWork,
            IPdfConverter pdfConverter,
            IRazorViewRenderer viewRenderer)
        {
            _unitOfWork = unitOfWork;
            _pdfConverter = pdfConverter;
            _viewRenderer = viewRenderer;
            _batchScheduleRepository = _unitOfWork.GetRepository<BatchSchedule>();
            _batchScheduleAllocationRepository = _unitOfWork.GetRepository<BatchScheduleAllocation>();
        }

        public async Task<long> CreateAsync(BatchScheduleCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _batchScheduleRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(BatchScheduleUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _batchScheduleRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Batch schedule not found");

            request.Map(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _batchScheduleRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Batch schedule not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<BatchScheduleViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _batchScheduleRepository.GetAsync(x => x.Id == id, BatchScheduleViewModel.SelectWithModules(), cancellationToken);
            return item;
        }

        public async Task<PagedCollection<BatchScheduleViewModel>> ListAsync(string scheduleStatus, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow.Date;
            scheduleStatus = scheduleStatus?.ToUpper();
            Expression<Func<BatchSchedule, bool>> predicate = null;
            if (scheduleStatus == "UPCOMING")
            {
                predicate = x => now < x.RegistrationStartDate.Date;
            }
            else if (scheduleStatus == "RUNNING")
            {
                predicate = x => now >= x.StartDate.Date && now <= x.EndDate.Date;
            }
            else if (scheduleStatus == "FINISHED")
            {
                predicate = x => now >= x.EndDate.Date;
            }

            var result = await _batchScheduleRepository.ListAsync(predicate, BatchScheduleViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<BatchScheduleParticipantViewModel>> ParticipantListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            Expression<Func<BatchScheduleAllocation, bool>> predicate = x => x.BatchScheduleId == batchScheduleId && x.Status == BatchScheduleAllocationStatus.Approved;

            var result = await _batchScheduleAllocationRepository.ListAsync(predicate, BatchScheduleParticipantViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> ListDropdownAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _batchScheduleRepository.ListAsync(x => new IdNameViewModel
            {
                Id = x.Id,
                Name = x.Name
            },
            pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> ListModuleAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var repo = _unitOfWork.GetRepository<Course_CourseModule>();
            var courseId = await _batchScheduleRepository
                .AsReadOnly()
                .Where(x => x.Id == batchScheduleId && !x.IsDeleted)
                .Select(x => x.CourseSchedule.CourseId)
                .FirstOrDefaultAsync();

            if (courseId == default)
                throw new ValidationException("Item not found");

            Expression<Func<Course_CourseModule, bool>> predicate = x => x.CourseId == courseId;

            var result = await repo.ListAsync(
                predicate,
                x => new IdNameViewModel
                {
                    Id = x.CourseModuleId,
                    Name = x.CourseModule.Name
                },
                pagingOptions,
                searchOptions,
                cancellationToken);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> EvaluationMethodListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {

            var courseId = await _batchScheduleRepository
                .AsReadOnly()
                .Where(x => x.Id == batchScheduleId && !x.IsDeleted)
                .Select(x => x.CourseSchedule.CourseId)
                .FirstOrDefaultAsync(cancellationToken);

            Expression<Func<BatchScheduleAllocation, bool>> predicate = x => x.BatchScheduleId == batchScheduleId && x.Status == BatchScheduleAllocationStatus.Approved;

            var result = await _unitOfWork.GetRepository<CourseEvaluationMethod>()
                .ListAsync(
                x => x.CourseId == courseId,
                x => new IdNameViewModel
                {
                    Id = x.EvaluationMethodId,
                    Name = x.EvaluationMethod.Name
                },
                pagingOptions,
                searchOptions);

            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> SessionProgressAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {

            var courseId = await _batchScheduleRepository
                .AsReadOnly()
                .Where(x => x.Id == batchScheduleId && !x.IsDeleted)
                .Select(x => x.CourseSchedule.CourseId)
                .FirstOrDefaultAsync(cancellationToken);

            Expression<Func<BatchScheduleAllocation, bool>> predicate = x => x.BatchScheduleId == batchScheduleId && x.Status == BatchScheduleAllocationStatus.Approved;

            var result = await _unitOfWork.GetRepository<CourseEvaluationMethod>()
                .ListAsync(
                x => x.CourseId == courseId,
                x => new IdNameViewModel
                {
                    Id = x.EvaluationMethodId,
                    Name = x.EvaluationMethod.Name
                },
                pagingOptions,
                searchOptions);

            return result;
        }

        public async Task<bool> UpdateGalleryAsync(BatchScheduleUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _batchScheduleRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Batch schedule not found");

            request.Map(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<byte[]> GenerateHonorariumSheetAsync(long batchScheduleId, CancellationToken cancellationToken = default)
        {
            List<HonorariumPdfModelModel> list = new List<HonorariumPdfModelModel>();
            var persons = await _unitOfWork.GetRepository<BatchScheduleAllocation>()
                .AsReadOnly()
                .Where(x => x.BatchScheduleId == batchScheduleId && x.Status == BatchScheduleAllocationStatus.Approved && !x.IsDeleted)
                .Select(x => new
                {
                    Name = x.Trainee.FullName,
                    DesignationId = x.Trainee.DesignationId,
                    Designation = x.Trainee.DesignationId != null ? x.Trainee.Designation.Name : "",
                })
                .ToListAsync(cancellationToken);

            var latestHonorarium = await _unitOfWork.GetRepository<Honorarium>()
                .AsReadOnly()
                .Where(x => x.HonorariumFor == HonorariumFor.Participant && !x.IsDeleted)
                .OrderByDescending(x => x.Year)
                .FirstOrDefaultAsync(cancellationToken);

            if (latestHonorarium != null)
            {
                var heads = await _unitOfWork.GetRepository<HonorariumHead>()
                    .Where(x => x.HonorariumId == latestHonorarium.Id && x.DesignationId != null && !x.IsDeleted)
                    .Select(x => new
                    {
                        DesignationId = x.DesignationId,
                        Head = x.Head,
                        Amount = x.Amount
                    })
                    .ToListAsync();

                if (heads.Count > 0)
                {
                    foreach (var person in persons)
                    {
                        var head = heads.FirstOrDefault(x => x.DesignationId == person.DesignationId);
                        var amount = head != null ? head.Amount : 0;
                        var tenPercentReduceAmount = (10.0 / 100.0) * amount;
                        list.Add(new HonorariumPdfModelModel
                        {
                            Designation = person.Designation,
                            Name = person.Name,
                            Amount = amount,
                            TenPercentReduceAmout = tenPercentReduceAmount,
                            NetAmount = amount - tenPercentReduceAmount
                        });
                    }
                }

            }

            var course = await _unitOfWork.GetRepository<BatchSchedule>()
                .AsReadOnly()
                .Where(x => x.Id == batchScheduleId && !x.IsDeleted)
                .Select(x => x.CourseSchedule.Course.Name)
                .FirstOrDefaultAsync();

            var model = new HonorariumSheetForParticipantsPdfModel
            {
                Date = DateTime.UtcNow,
                CourseName = course ?? "",
                Participants = list
            };

            var htmlContent = await _viewRenderer.RenderViewToStringAsync("/Views/honorarium-for-participants.cshtml", model);
            var pdfBytes = _pdfConverter.Convert(htmlContent);
            return pdfBytes;
        }

    }
}
