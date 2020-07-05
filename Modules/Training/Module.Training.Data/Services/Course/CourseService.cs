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
using System;
using Module.Core.Shared;

namespace Module.Training.Data
{
    public class CourseService : ICourseService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<CourseMethod> _courseMethodRepository;
        private readonly IRepository<Course_CourseModule> _courseCourseModuleRepository;
        private readonly IRepository<CourseEvaluationMethod> _courseEvaluationMethodRepository;

        public CourseService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = _unitOfWork.GetRepository<Course>();
            _courseMethodRepository = _unitOfWork.GetRepository<CourseMethod>();
            _courseCourseModuleRepository = _unitOfWork.GetRepository<Course_CourseModule>();
            _courseEvaluationMethodRepository = _unitOfWork.GetRepository<CourseEvaluationMethod>();
        }

        public async Task<long> CreateAsync(CourseCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _courseRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var methods = request.Methods.Select(x => new CourseMethod
            {
                MethodId = x,
                CourseId = entity.Id
            });

            await _courseMethodRepository.AddRangeAsync(methods);

            var modules = request.Modules.Select(x => new Course_CourseModule
            {
                CourseModuleId = x,
                CourseId = entity.Id
            });
            await _courseCourseModuleRepository.AddRangeAsync(modules);

            var evaluationMethods = request.EvaluationMethods.Select(x => new CourseEvaluationMethod
            {
                EvaluationMethodId = x.EvaluationMethod.Id,
                Mark = x.Mark,
                CourseId = entity.Id
            });
            await _courseEvaluationMethodRepository.AddRangeAsync(evaluationMethods);

            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(CourseUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _courseRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Course not found");

            request.Map(entity);

            // modules
            await _courseCourseModuleRepository.UpdateAsync(
                request.Modules,
                x => x.CourseId == request.Id,
                x => x.CourseModuleId,
                x => new Course_CourseModule
                {
                    CourseModuleId = x,
                    CourseId = request.Id
                },
                ids => x => ids.Contains(x.CourseModuleId) && x.CourseId == request.Id);

            // methods
            await _courseMethodRepository.UpdateAsync(
                request.Methods,
                x => x.CourseId == request.Id,
                x => x.MethodId,
                x => new CourseMethod
                {
                    MethodId = x,
                    CourseId = request.Id
                },
                ids => x => ids.Contains(x.MethodId) && x.CourseId == request.Id);

            // evaluation methods

            foreach (var evaluationMethod in request.EvaluationMethods)
            {
                if (evaluationMethod.Id.HasValue)
                {
                    // update
                    var dbEvaluationMethod = await _courseEvaluationMethodRepository
                        .Where(x => x.Id == evaluationMethod.Id.Value && x.CourseId == request.Id && !x.IsDeleted)
                        .FirstOrDefaultAsync();

                    if (dbEvaluationMethod != null)
                    {
                        dbEvaluationMethod.Mark = evaluationMethod.Mark;
                    }
                }
                else
                {
                    // new
                    var newEvaluationMethod = new CourseEvaluationMethod
                    {
                        EvaluationMethodId = evaluationMethod.EvaluationMethod.Id,
                        Mark = evaluationMethod.Mark,
                        CourseId = request.Id
                    };
                    await _courseEvaluationMethodRepository.AddAsync(newEvaluationMethod);
                }
            }

            // delete course evaluation method
            var requestEvaluationMethodIds = request.EvaluationMethods
                .Where(x => x.Id.HasValue)
                .Select(x => x.Id.Value);

            var evaluationMethodToBeDelete = await _courseEvaluationMethodRepository
                .Where(x => x.CourseId == request.Id && !requestEvaluationMethodIds.Contains(x.Id))
    .ToListAsync();

            _courseEvaluationMethodRepository.RemoveRange(evaluationMethodToBeDelete);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _courseRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Course not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<CourseViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _courseRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(CourseViewModel.Select())
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Course not found");

            item.Modules = await _courseCourseModuleRepository
                .AsReadOnly()
                .Where(x => x.CourseId == id && !x.IsDeleted)
                .Select(x => new IdNameViewModel { Id = x.CourseModuleId, Name = x.CourseModule.Name })
                .ToListAsync();

            item.Methods = await _courseMethodRepository
                .AsReadOnly()
                .Where(x => x.CourseId == id && !x.IsDeleted)
                .Select(x => new IdNameViewModel { Id = x.MethodId, Name = x.Method.Name })
                .ToListAsync();

            item.EvaluationMethods = await _courseEvaluationMethodRepository
                .AsReadOnly()
                .Where(x => x.CourseId == id && !x.IsDeleted)
                .Select(CourseEvaluationMethodViewModel.Select())
                .ToListAsync();

            return item;
        }

        public async Task<PagedCollection<CourseListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _courseRepository.ListAsync(null, CourseListViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

    }
}
