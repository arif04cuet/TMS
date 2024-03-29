﻿using Infrastructure;
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
        private readonly IMediaService _mediaService;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<CourseMethod> _courseMethodRepository;
        private readonly IRepository<Course_CourseModule> _courseCourseModuleRepository;
        private readonly IRepository<CourseEvaluationMethod> _courseEvaluationMethodRepository;

        public CourseService(
            IUnitOfWork unitOfWork,
            IMediaService mediaService)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
            _courseRepository = _unitOfWork.GetRepository<Course>();
            _courseMethodRepository = _unitOfWork.GetRepository<CourseMethod>();
            _courseCourseModuleRepository = _unitOfWork.GetRepository<Course_CourseModule>();
            _courseEvaluationMethodRepository = _unitOfWork.GetRepository<CourseEvaluationMethod>();
        }

        public async Task<long> CreateAsync(CourseCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();

            if (request.Image.HasValue)
                entity.ImageId = request.Image;

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
                CourseId = entity.Id,
                CourseModuleId = x.CourseModule.Id,
                Duration = x.Duration,
                Marks = x.Marks
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

            if (result > 0 && request.Image.HasValue)
                await _mediaService.UseAsync(request.Image);


            return entity.Id;
        }

        public async Task<bool> UpdateAsync(CourseUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _courseRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Course not found");

            entity = request.Map(entity);

            long? oldImageId = null;
            long? newImageId = null;

            //upload image
            if (request.Image.HasValue)
            {
                oldImageId = entity.ImageId;
                entity.ImageId = request.Image;
                newImageId = entity.ImageId;
            }
            else
            {
                oldImageId = entity.ImageId;
                entity.ImageId = null;
            }

            // modules
            foreach (var module in request.Modules)
            {
                if (module.Id.HasValue)
                {
                    // update
                    var dbCourseModule = await _courseCourseModuleRepository
                        .Where(x => x.Id == module.Id.Value && x.CourseId == request.Id && !x.IsDeleted)
                        .FirstOrDefaultAsync();

                    if (dbCourseModule != null)
                    {
                        dbCourseModule.Marks = module.Marks;
                        dbCourseModule.Duration = module.Duration;
                    }
                }
                else
                {
                    // new
                    var newCourseModule = new Course_CourseModule
                    {
                        CourseId = request.Id,
                        CourseModuleId = module.CourseModule.Id,
                        Marks = module.Marks,
                        Duration = module.Duration,
                    };
                    await _courseCourseModuleRepository.AddAsync(newCourseModule);
                }
            }

            // delete course course module
            var requestCourseModuleIds = request.Modules
                .Where(x => x.Id.HasValue)
                .Select(x => x.Id.Value);

            var courseModuleToBeDelete = await _courseCourseModuleRepository
                .Where(x => x.CourseId == request.Id && !requestCourseModuleIds.Contains(x.Id))
    .ToListAsync();

            _courseCourseModuleRepository.RemoveRange(courseModuleToBeDelete);

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

            if (result > 0)
            {
                if (newImageId.HasValue)
                    await _mediaService.UseAsync(newImageId);

                if (oldImageId.HasValue)
                    await _mediaService.DeleteMediaAsync(oldImageId);
            }

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
                .Select(CourseCourseModuleViewModel.Select())
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

        public async Task<bool> DeleteImageAsync(long imageId, long? courseId, CancellationToken cancellationToken = default)
        {
            long result = 0;
            if (courseId.HasValue)
            {
                var entity = await _courseRepository
                .FirstOrDefaultAsync(x => x.Id == courseId && !x.IsDeleted);

                if (entity == null)
                    throw new NotFoundException("Image not found");

                if (entity.ImageId.HasValue)
                {
                    // delete image association
                    entity.ImageId = null;
                    result = await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    courseId = null;
                }
            }

            // delete physical file
            if ((courseId.HasValue && result > 0) || !courseId.HasValue)
                await _mediaService.DeleteMediaAsync(imageId);

            return result > 0;
        }

    }
}
