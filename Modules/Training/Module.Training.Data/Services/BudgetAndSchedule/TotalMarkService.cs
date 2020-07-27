using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Module.Training.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure;
using Msi.UtilityKit.Pagination;

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
                if (mark.Id.HasValue)
                {
                    // update
                    var dbMark = await _totalMarkRepository
                        .Where(x => x.Id == mark.Id.Value && x.BatchScheduleId == request.BatchSchedule && !x.IsDeleted)
                        .FirstOrDefaultAsync();
                    if (dbMark == null)
                        throw new ValidationException("Total mark not found");

                    dbMark.Mark = mark.Mark;
                }
                else
                {
                    // new
                    var totalMark = new TotalMark
                    {
                        Mark = mark.Mark,
                        //ParticipantId = mark.Participant.Id,
                        //EvaluationMethodId = mark.CourseEvaluationMethodId,
                        BatchScheduleId = request.BatchSchedule
                    };
                    await _totalMarkRepository.AddAsync(totalMark);
                }
            }
            var result = await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<TotalMarkViewModel>> ListAsync(long batchScheduleId, CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.GetRepository<BatchSchedule>()
                .AsReadOnly()
                .Where(x => x.Id == batchScheduleId && !x.IsDeleted)
                .SelectMany(x => x.CourseSchedule.Course.EvaluationMethods);

            var evaluationMethods = await query
                .Select(x => new TotalMarkEvaluationMethodViewModel
                {
                    Id = x.EvaluationMethodId,
                    Name = x.EvaluationMethod.Name
                })
                .ToListAsync();

            var participants = await _unitOfWork.GetRepository<BatchScheduleAllocation>()
                .AsReadOnly()
                .Where(x => x.BatchScheduleId == batchScheduleId
                && x.Status == BatchScheduleAllocationStatus.Approved
                && !x.IsDeleted)
                .ToListAsync();

            List<TotalMarkViewModel> marks = new List<TotalMarkViewModel>();

            //foreach (var participant in participants)
            //{
            //    var totalMark = _unitOfWork.GetRepository<TotalMark>()
            //        .FirstOrDefaultAsync(x => x.BatchScheduleId == batchScheduleId
            //        && x.ParticipantId == participant.Id
            //        && !x.IsDeleted)
            //    new TotalMarkViewModel
            //    {
            //        Id =  
            //    }
            //}

            //var totalMarkQuery = _unitOfWork.GetRepository<TotalMark>()
            //    .AsReadOnly()
            //    .Where(x => x.BatchScheduleId == batchScheduleId && !x.IsDeleted);

            //var totalMarkCount = await totalMarkQuery.Select(x => x.Id).CountAsync();

            //IEnumerable<TotalMarkListViewModel> totalMarks = null;

            //if (totalMarkCount == 0)
            //{
            //    var participants = await participantsQuery
            //        .Select(x => new TotalMarkListViewModel
            //        {
            //            Participant = new IdNameViewModel
            //            {
            //                Id = x.Id,
            //                Name = x.Trainee.FullName
            //            }
            //        })
            //        .ToListAsync();

            //    var _participants = new List<TotalMarkListViewModel>();
            //    foreach (var participant in participants)
            //    {
            //        foreach (var evaluationMethod in evaluationMethods)
            //        {
            //            _participants.Add(new TotalMarkListViewModel
            //            {
            //                Participant = new IdNameViewModel
            //                {
            //                    Id = participant.Participant.Id,
            //                    Name = participant.Participant.Name
            //                },
            //                CourseEvaluationMethodId = evaluationMethod.CourseEvaluationMethodId,
            //                EvaluationMethod = new IdNameViewModel
            //                {
            //                    Id = evaluationMethod.EvaluationMethodId,
            //                    Name = evaluationMethod.EvaluationMethodName
            //                }
            //            });
            //        }
            //    }

            //    totalMarks = _participants;
            //}
            //else
            //{
            //    totalMarks = await totalMarkQuery
            //        .OrderBy(x => x.ParticipantId).ThenBy(x => x.EvaluationMethod.Id)
            //        .Select(x => new TotalMarkListViewModel
            //        {
            //            Id = x.Id,
            //            Participant = new IdNameViewModel
            //            {
            //                Id = x.ParticipantId.Value,
            //                Name = x.Participant.Trainee.FullName
            //            },
            //            CourseEvaluationMethodId = x.EvaluationMethod.Id,
            //            EvaluationMethod = new IdNameViewModel
            //            {
            //                Id = x.EvaluationMethod.EvaluationMethodId,
            //                Name = x.EvaluationMethod.EvaluationMethod.Name
            //            },
            //            Mark = x.Mark
            //        })
            //        .ToListAsync();
            //}

            //var pagingOptions = new PagingOptions
            //{
            //    Limit = totalMarks.Count(),
            //    Offset = 0
            //};
            //var result = IEnumerable<TotalMarkViewModel>(null, 0, pagingOptions);
            return null;
        }

    }
}
