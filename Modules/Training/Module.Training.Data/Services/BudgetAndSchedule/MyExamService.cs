using Dapper;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class MyExamService : IMyExamService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Exam> _examRepository;
        private readonly IRepository<ExamParticipant> _examParticipantRepository;
        private readonly IRepository<ExamQuestion> _examQuestionRepository;
        private readonly IRepository<ExamAnswer> _examAnswerRepository;
        private readonly IDbConnection _dbConnection;
        private readonly IAppService _appService;

        public MyExamService(
            IUnitOfWork unitOfWork,
            IAppService appService)
        {
            _unitOfWork = unitOfWork;
            _appService = appService;
            _examRepository = _unitOfWork.GetRepository<Exam>();
            _dbConnection = _unitOfWork.GetConnection();
            _examParticipantRepository = _unitOfWork.GetRepository<ExamParticipant>();
            _examQuestionRepository = _unitOfWork.GetRepository<ExamQuestion>();
            _examAnswerRepository = _unitOfWork.GetRepository<ExamAnswer>();
        }

        public async Task<long> SubmitAnswerAsync(SubmitExamAnswerRequest request, CancellationToken cancellationToken = default)
        {
            // check logged in user took this exam or not
            var user = _appService.GetAuthenticatedUser();
            if (user == null || !user.Exists())
                throw new ValidationException("User not found");

            var examParticipant = await _examParticipantRepository
                .FirstOrDefaultAsync(x => x.Participant.TraineeId == user.Id
                && x.ExamId == request.ExamId
                && !x.IsDeleted, true);

            // if (examParticipant != null)
            // throw new ValidationException("You already took this exam.");

            var exam = await _examRepository
                .FirstOrDefaultAsync(x => x.Id == request.ExamId && !x.IsDeleted, true);

            if (exam == null)
                throw new ValidationException("Exam not found");

            var allocation = await _unitOfWork.GetRepository<BatchScheduleAllocation>()
                .FirstOrDefaultAsync(x => x.BatchScheduleId == exam.BatchScheduleId && x.TraineeId == user.Id
                && x.Status == BatchScheduleAllocationStatus.Approved
                && !x.IsDeleted, true);

            if (allocation == null)
                throw new ValidationException("Allocation not found");

            int totalMark = 0;

            foreach (var item in request.Answers)
            {
                var dbExamAnswer = await _examAnswerRepository
                    .FirstOrDefaultAsync(x => x.ExamId == exam.Id
                    && x.AllocationId == allocation.Id
                    && x.QuestionId == item.Question
                    && !x.IsDeleted);

                if (dbExamAnswer == null)
                {
                    var newExamAnswer = new ExamAnswer
                    {
                        AllocationId = allocation.Id,
                        ExamId = exam.Id,
                        QuestionId = item.Question,
                        WrittenAnswer = item.WrittenAnswer,
                        McqAnswerId = item.McqAnswer
                    };
                    await _examAnswerRepository.AddAsync(newExamAnswer);
                }
                else
                {
                    dbExamAnswer.McqAnswerId = item.McqAnswer;
                    dbExamAnswer.WrittenAnswer = item.WrittenAnswer;
                }

                if (item.McqAnswer.HasValue)
                {
                    var mark = await _unitOfWork.GetRepository<ExamQuestion>()
                        .AsReadOnly()
                        .Where(x => x.ExamId == exam.Id
                        && x.QuestionId == item.Question
                        && !x.IsDeleted)
                        .Select(x => new { Question = x.QuestionId, Mark = x.Mark })
                        .FirstOrDefaultAsync(cancellationToken);

                    if (mark != null)
                    {
                        var option = await _unitOfWork.GetRepository<QuestionOption>()
                            .AsReadOnly()
                            .Where(x => x.QuestionId == mark.Question
                            && x.Id == item.McqAnswer
                            && x.IsCorrect
                            && !x.IsDeleted)
                            .Select(x => new { Id = x.Id })
                            .FirstOrDefaultAsync(cancellationToken);

                        if (option != null)
                        {
                            totalMark += mark.Mark;
                        }
                    }

                }
            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                var dbExamParticiapnt = await _examParticipantRepository
                    .FirstOrDefaultAsync(x => x.ExamId == exam.Id
                    && x.ParticipantId == allocation.Id
                    && !x.IsDeleted);

                if (dbExamParticiapnt == null)
                {
                    var examParticiapnt = new ExamParticipant
                    {
                        ExamId = exam.Id,
                        ParticipantId = allocation.Id,
                        Mark = totalMark
                    };
                    await _examParticipantRepository.AddAsync(examParticiapnt, cancellationToken);
                }
                else
                {
                    dbExamParticiapnt.Mark = totalMark;
                }
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return result;
        }

        public async Task<ExamViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            // check logged in user took this exam or not
            var user = _appService.GetAuthenticatedUser();
            if (user == null || !user.Exists())
                throw new ValidationException("User not found");

            var participant = await _examParticipantRepository
                .FirstOrDefaultAsync(x => x.Participant.TraineeId == user.Id
                && x.ExamId == id
                && !x.IsDeleted, true);

            // if (participant != null)
            // throw new ValidationException("You already took this exam.");

            var item = await _examRepository.GetAsync(x => x.Id == id, ExamViewModel.Select(), cancellationToken);

            if (item != null)
            {
                item.Questions = await _unitOfWork.GetRepository<ExamQuestion>()
                    .AsReadOnly()
                    .Where(x => x.ExamId == item.Id && !x.IsDeleted)
                    .Select(ExamQuestionViewModel.Select())
                    .ToListAsync(cancellationToken);
            }

            return item;
        }

        public async Task<PagedCollection<MyExamListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            long userId = _appService.GetAuthenticatedUser().Id;
             var batchScheduleIds = await _unitOfWork.GetRepository<BatchScheduleAllocation>()
                .AsReadOnly()
                .Where(x => x.TraineeId == userId
                && x.Status == BatchScheduleAllocationStatus.Approved
                && !x.IsDeleted)
                .Select(x => x.BatchScheduleId)
                .ToListAsync();

            var query = _unitOfWork.GetRepository<Exam>()
                .Where(x => batchScheduleIds.Contains(x.BatchScheduleId)
                && x.ExamDate <= DateTime.UtcNow
                && x.Status == ExamStatus.Pending
                && x.QuestionType.HasValue
                && x.IsOnline
                && !x.IsDeleted);

            var items = await query
                .Select(x => new MyExamListViewModel
                {
                    Id = x.Id,
                    BatchSchedule = x.BatchSchedule.Name,
                    CourseSchedule = x.BatchSchedule.CourseSchedule.Name,
                    Name = x.Name,
                    Course = x.BatchSchedule.CourseSchedule.Name,
                    DateTime = x.ExamDate
                })
                .ApplyPagination(pagingOptions)
                .ToListAsync();

            foreach (var item in items)
            {
                var count = await _unitOfWork.GetRepository<ExamParticipant>()
                    .AsReadOnly()
                    .Where(x => x.Participant.TraineeId == userId
                    && x.ExamId == item.Id
                    && !x.IsDeleted)
                    .Select(x => x.Id)
                    .CountAsync();
                item.Attended = count > 0;
            }

            var total = query.Select(x => x.Id).Count();

            var result = new PagedCollection<MyExamListViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
