using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Module.Core.Data;
using Module.Core.Shared;
using System.Linq.Expressions;
using System;

namespace Module.Training.Data
{
    public class CourseModuleService : ICourseModuleService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CourseModule> _courseModuleRepository;
        private readonly IRepository<CourseModuleTopic> _courseModuleTopicRepository;

        public CourseModuleService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseModuleRepository = _unitOfWork.GetRepository<CourseModule>();
            _courseModuleTopicRepository = _unitOfWork.GetRepository<CourseModuleTopic>();
        }

        public async Task<long> CreateAsync(CourseModuleCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _courseModuleRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var topics = request.Topics.Select(x => new CourseModuleTopic
            {
                CourseModuleId = entity.Id,
                TopicId = x
            });

            await _courseModuleTopicRepository.AddRangeAsync(topics);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(CourseModuleUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _courseModuleRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Course module not found");

            request.Map(entity);

            // topics
            await _courseModuleTopicRepository.UpdateAsync(
                request.Topics,
                x => x.CourseModuleId == request.Id,
                x => x.TopicId,
                x => new CourseModuleTopic
                {
                    TopicId = x,
                    CourseModuleId = request.Id
                },
                ids => x => ids.Contains(x.TopicId) && x.CourseModuleId == request.Id);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _courseModuleRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Course module not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<CourseModuleViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _courseModuleRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(CourseModuleViewModel.Select())
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Course module not found");

            item.Topics = await _courseModuleTopicRepository
                .AsReadOnly()
                .Where(x => x.CourseModuleId == id && !x.IsDeleted)
                .Select(x => new IdNameViewModel { Id = x.TopicId, Name = x.Topic.Name })
                .ToListAsync();

            return item;
        }

        public async Task<PagedCollection<CourseModuleViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _courseModuleRepository.ListAsync(null, CourseModuleViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> ListTopicAsync(long courseModuleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            Expression<Func<CourseModuleTopic, bool>> predicate = x => x.CourseModuleId == courseModuleId;
            var result = await _courseModuleTopicRepository.ListAsync(
                predicate,
                x => new IdNameViewModel
                {
                    Id = x.TopicId,
                    Name = x.Topic.Name
                },
                pagingOptions,
                searchOptions,
                cancellationToken);
            return result;
        }

    }
}
