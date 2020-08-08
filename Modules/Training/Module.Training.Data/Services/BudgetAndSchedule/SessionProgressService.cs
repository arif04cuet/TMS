using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class SessionProgressService : ISessionProgressService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IPdfConverter _pdfConverter;
        private readonly IRazorViewRenderer _viewRenderer;
        private readonly IRepository<RoutinePeriod> _routinePeriodRepository;

        public SessionProgressService(
            IUnitOfWork unitOfWork,
            IPdfConverter pdfConverter,
            IRazorViewRenderer viewRenderer)
        {
            _unitOfWork = unitOfWork;
            _pdfConverter = pdfConverter;
            _viewRenderer = viewRenderer;
            _routinePeriodRepository = _unitOfWork.GetRepository<RoutinePeriod>();
        }

        public async Task<long> CompleteMultipleAsync(SessionProgressCompleteRequest request, CancellationToken cancellationToken = default)
        {
            var result = 0L;
            foreach (var item in request.RoutinePeriods)
            {
                result += await CompleteAsync(item, cancellationToken);
            }
            return result;
        }

        public async Task<byte[]> CompleteMultipleAndGenerateSheetAsync(SessionProgressCompleteRequest request, CancellationToken cancellationToken = default)
        {
            if (request.RoutinePeriods.Count() <= 0)
                throw new ValidationException("No session progress to complete.");

            var result = await CompleteMultipleAsync(request, cancellationToken);

            var bytes = await GenerateSheetAsync(x => request.RoutinePeriods.Contains(x.Id), request.BatchScheduleId);
            return bytes;
        }

        public async Task<IEnumerable<SessionProgressViewModel>> ListAsync(long batchScheduleId, long? moduleId = null, CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.GetRepository<ClassRoutine>()
                .AsReadOnly()
                .Where(x => x.BatchScheduleId == batchScheduleId)
                .SelectMany(x => x.RoutineModules);

            if (moduleId.HasValue)
            {
                query = query.Where(x => x.CourseModuleId == moduleId.Value);
            }

            var modules = await query
                .Select(x => new
                {
                    CourseModule = new IdNameViewModel { Id = x.CourseModule.Id, Name = x.CourseModule.Name },
                    ClassRoutineModuleId = x.Id
                })
                .ToListAsync();

            List<SessionProgressViewModel> progress = new List<SessionProgressViewModel>();
            foreach (var module in modules)
            {
                var routinePeriods = await _unitOfWork.GetRepository<RoutinePeriod>()
                    .AsReadOnly()
                    .Where(x => x.Routine.ModuleId == module.ClassRoutineModuleId && !x.IsDeleted)
                    .Select(x => new SessionProgressViewModel
                    {
                        Topic = new IdNameViewModel { Id = x.Topic.Id, Name = x.Topic.Name },
                        Completed = x.SessionCompleted,
                        CourseModule = module.CourseModule,
                        Id = x.Id
                    })
                    .ToListAsync();

                progress.AddRange(routinePeriods);
            }

            return progress;
        }

        public async Task<long> CompleteAsync(long routinePeriodId, CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.GetRepository<RoutinePeriod>()
                .FirstOrDefaultAsync(x => x.Id == routinePeriodId && !x.IsDeleted);

            if (entity != null)
            {
                entity.SessionCompleted = true;
            }
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<byte[]> CompleteAndGenerateSheetAsync(long batchScheduleId, long routinePeriodId, CancellationToken cancellationToken = default)
        {
            await CompleteAsync(routinePeriodId);
            var pdfBytes = await GenerateSheetAsync(x => x.Id == routinePeriodId, batchScheduleId);
            return pdfBytes;
        }

        private async Task<byte[]> GenerateSheetAsync(Expression<Func<RoutinePeriod, bool>> where, long batchScheduleId)
        {
            var persons = _routinePeriodRepository
                .AsReadOnly()
                .Where(where)
                .Select(x => new HonorariumPdfModelModel
                {
                    Amount = x.ResourcePerson.HonorariumHead.Amount,
                    Name = x.ResourcePerson.User.FullName,
                    Designation = x.ResourcePerson.User.DesignationId != null ? x.ResourcePerson.User.Designation.Name : "",
                    TenPercentReduceAmout = (10.0 / 100.0) * x.ResourcePerson.HonorariumHead.Amount,
                    NetAmount = x.ResourcePerson.HonorariumHead.Amount - ((10.0 / 100.0) * x.ResourcePerson.HonorariumHead.Amount)
                });

            var course = await _unitOfWork.GetRepository<BatchSchedule>()
                .AsReadOnly()
                .Where(x => x.Id == batchScheduleId && !x.IsDeleted)
                .Select(x => x.CourseSchedule.Course.Name)
                .FirstOrDefaultAsync();

            var model = new HonorariumSheetForResourcePersonsPdfModel
            {
                Date = DateTime.UtcNow,
                CourseName = course ?? "",
                ResourcePersons = persons
            };
            var htmlContent = await _viewRenderer.RenderViewToStringAsync("/Views/honorarium-for-resource-person.cshtml", model);
            var pdfBytes = _pdfConverter.Convert(htmlContent);
            return pdfBytes;
        }

    }
}
