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

        public BatchScheduleService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

    }
}
