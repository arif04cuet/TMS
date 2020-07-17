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
        private readonly IRepository<CourseModule_Course> _courseModuleCourseRepository;

        public CourseModuleService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseModuleRepository = _unitOfWork.GetRepository<CourseModule>();
            _courseModuleTopicRepository = _unitOfWork.GetRepository<CourseModuleTopic>();
            _courseModuleCourseRepository = _unitOfWork.GetRepository<CourseModule_Course>();
        }

        public async Task<long> CreateAsync(CourseModuleCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _courseModuleRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var topics = request.Topics.Select(x => new CourseModuleTopic
            {
                CourseModuleId = entity.Id,
                TopicId = x.Topic.Id,
                Marks = x.Marks,
                Duration = x.Duration
            });

            if (request.Courses != null)
            {
                var courseModuleCourses = request.Courses.Select(x => new CourseModule_Course
                {
                    CourseId = x,
                    CourseModuleId = entity.Id
                });
                await _courseModuleCourseRepository.AddRangeAsync(courseModuleCourses);
            }

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

            await _courseModuleCourseRepository.UpdateAsync(
                request.Courses,
                x => x.CourseModuleId == request.Id,
                x => x.CourseId,
                x => new CourseModule_Course
                {
                    CourseId = x,
                    CourseModuleId = request.Id
                },
                ids => x => ids.Contains(x.CourseId) && x.CourseModuleId == request.Id);

            // topics
            foreach (var topic in request.Topics)
            {
                if (topic.Id.HasValue)
                {
                    // update
                    var dbCourseModuleTopic = await _courseModuleTopicRepository
                        .Where(x => x.Id == topic.Id.Value && x.CourseModuleId == request.Id && !x.IsDeleted)
                        .FirstOrDefaultAsync();

                    if (dbCourseModuleTopic != null)
                    {
                        dbCourseModuleTopic.Marks = topic.Marks;
                        dbCourseModuleTopic.Duration = topic.Duration;
                    }
                }
                else
                {
                    // new
                    var newCourseModuleTopic = new CourseModuleTopic
                    {
                        TopicId = topic.Topic.Id,
                        CourseModuleId = request.Id,
                        Marks = topic.Marks,
                        Duration = topic.Duration
                    };
                    await _courseModuleTopicRepository.AddAsync(newCourseModuleTopic);
                }
            }

            // delete topics
            var requestCourseModuleTopicIds = request.Topics
                .Where(x => x.Id.HasValue)
                .Select(x => x.Id.Value);

            var courseModuleTopicsToBeDelete = await _courseModuleTopicRepository
                .Where(x => x.CourseModuleId == request.Id && !requestCourseModuleTopicIds.Contains(x.Id))
    .ToListAsync();

            _courseModuleTopicRepository.RemoveRange(courseModuleTopicsToBeDelete);

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
                .Select(CourseModuleTopicViewModel.Select())
                .ToListAsync();

            item.Courses = await _courseModuleCourseRepository
                .AsReadOnly()
                .Where(x => x.CourseModuleId == id && !x.IsDeleted)
                .Select(x => new IdNameViewModel { Id = x.CourseId, Name = x.Course.Name })
                .ToListAsync();

            return item;
        }

        public async Task<PagedCollection<CourseModuleListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _courseModuleRepository.ListAsync(null, CourseModuleListViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<CourseModuleTopicListViewModel>> ListTopicAsync(long courseModuleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            Expression<Func<CourseModuleTopic, bool>> predicate = x => x.CourseModuleId == courseModuleId;
            var result = await _courseModuleTopicRepository.ListAsync(
                x => x.CourseModuleId == courseModuleId,
                CourseModuleTopicListViewModel.Select(),
                pagingOptions,
                searchOptions,
                cancellationToken);
            return result;
        }

        public async Task<PagedCollection<IdNameViewModel>> ListMethodAsync(long courseModuleId)
        {
            var items = await _courseModuleTopicRepository
                .Where(x => x.CourseModuleId == courseModuleId && !x.IsDeleted && x.Topic.MethodId != null)
                .Select(x => new IdNameViewModel { Id = x.Topic.Method.Id, Name = x.Topic.Method.Name })
                .ToListAsync();
            var total = items.Count();

            var result = new PagedCollection<IdNameViewModel>(items, total, new PagingOptions { Limit = total, Offset = 0 });

            return result;
        }

    }
}
