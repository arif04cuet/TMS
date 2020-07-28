using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Training.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class TotalMarkService : ITotalMarkService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TotalMark> _totalMarkRepository;

        public TotalMarkService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _totalMarkRepository = _unitOfWork.GetRepository<TotalMark>();
        }

        public async Task<long> UpdateAsync(TotalMarkUpdateRequest request)
        {
            foreach (var mark in request.Marks)
            {
                if (mark.TotalMarkId.HasValue)
                {
                    // update
                    foreach (var item in mark.EvaluationMethods)
                    {
                        var dbMark = await _totalMarkRepository
                            .Where(x => x.Id == mark.TotalMarkId
                            && x.BatchScheduleId == request.BatchSchedule
                            && x.EvaluationMethodId == item.Id
                            && !x.IsDeleted)
                            .FirstOrDefaultAsync();

                        if (dbMark != null)
                        {
                            dbMark.Mark = item.Mark;
                        }
                    }
                }
                else
                {
                    // new
                    foreach (var item in mark.EvaluationMethods)
                    {
                        await _totalMarkRepository.AddAsync(new TotalMark
                        {
                            Mark = item.Mark,
                            ParticipantId = mark.BatchAllocationId,
                            BatchScheduleId = request.BatchSchedule,
                            EvaluationMethodId = item.Id
                        });
                    }
                }
            }
            var result = await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<TotalMarkViewModel>> ListAsync(long batchScheduleId, CancellationToken cancellationToken = default)
        {
            var evaluationMethods = await _unitOfWork.GetRepository<BatchSchedule>()
                .AsReadOnly()
                .Where(x => x.Id == batchScheduleId && !x.IsDeleted)
                .SelectMany(x => x.CourseSchedule.Course.EvaluationMethods)
                .Select(x => new TotalMarkEvaluationMethodViewModel
                {
                    Id = x.EvaluationMethodId,
                    Name = x.EvaluationMethod.Name
                })
                .ToListAsync();

            var allocations = await _unitOfWork.GetRepository<BatchScheduleAllocation>()
                .AsReadOnly()
                .Where(x => x.BatchScheduleId == batchScheduleId
                && x.Status == BatchScheduleAllocationStatus.Approved
                && !x.IsDeleted)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Trainee.FullName
                })
                .ToListAsync();

            List<TotalMarkViewModel> marks = new List<TotalMarkViewModel>();

            foreach (var allocation in allocations)
            {
                var totalMark = await _totalMarkRepository
                    .AsReadOnly()
                    .Where(x => x.BatchScheduleId == batchScheduleId
                    && x.ParticipantId == allocation.Id
                    && !x.IsDeleted)
                    .Select(x => new { Id = x.Id, Mark = x.Mark })
                    .FirstOrDefaultAsync();

                var mark = new TotalMarkViewModel
                {
                    TotalMarkId = totalMark?.Id,
                    ParticipantName = allocation.Name,
                    BatchAllocationId = allocation.Id,
                    EvaluationMethods = new List<TotalMarkEvaluationMethodViewModel>()
                    //Mark = totalMark == null ? 0 : totalMark.Mark
                };
                marks.Add(mark);
                foreach (var evaluationMethod in evaluationMethods)
                {
                    var evaluationTotalMark = await _unitOfWork.GetRepository<TotalMark>()
                    .AsReadOnly()
                    .Where(x => x.BatchScheduleId == batchScheduleId
                    && x.ParticipantId == allocation.Id
                    && x.EvaluationMethodId == evaluationMethod.Id
                    && !x.IsDeleted)
                    .Select(x => new { Id = x.Id, Mark = x.Mark })
                    .FirstOrDefaultAsync();

                    var listEvaluationMethod = mark.EvaluationMethods.FirstOrDefault(x => x.Id == evaluationMethod.Id);
                    if (listEvaluationMethod == null)
                    {
                        listEvaluationMethod = new TotalMarkEvaluationMethodViewModel
                        {
                            Id = evaluationMethod.Id,
                            Name = evaluationMethod.Name,
                            Mark = evaluationTotalMark == null ? 0 : evaluationTotalMark.Mark
                        };
                        mark.EvaluationMethods.Add(listEvaluationMethod);
                    }
                    else
                    {
                        listEvaluationMethod.Mark = evaluationTotalMark == null ? 0 : evaluationTotalMark.Mark;
                    }
                }
            }

            return marks;
        }

    }
}
