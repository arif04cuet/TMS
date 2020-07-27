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
        }

        public async Task<long> CreateAsync(ExamCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _examRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var questions = request.Questions.Select(x => new ExamQuestion
            {
                ExamId = entity.Id,
                QuestionId = x.Question.Id,
                Mark = x.Mark
            });
            await _examQuestionRepository.AddRangeAsync(questions);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(ExamUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _examRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Exam not found");

            request.Map(entity);

            // questions
            foreach (var question in request.Questions)
            {
                if (question.Id.HasValue)
                {
                    // update
                    var dbQuestion = await _examQuestionRepository
                        .Where(x => x.Id == question.Id.Value && x.ExamId == request.Id && !x.IsDeleted)
                        .FirstOrDefaultAsync();

                    if (dbQuestion != null)
                    {
                        dbQuestion.Mark = question.Mark;
                    }
                }
                else
                {
                    // new
                    var newExamQuestion = new ExamQuestion
                    {
                        ExamId = request.Id,
                        QuestionId = question.Question.Id,
                        Mark = question.Mark
                    };
                    await _examQuestionRepository.AddAsync(newExamQuestion);
                }
            }

            // delete question
            var requestExamQuestionIds = request.Questions
                .Where(x => x.Id.HasValue)
                .Select(x => x.Id.Value);

            var examQuestionToBeDelete = await _examQuestionRepository
                .Where(x => x.ExamId == request.Id && !requestExamQuestionIds.Contains(x.Id))
    .ToListAsync();

            _examQuestionRepository.RemoveRange(examQuestionToBeDelete);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _examRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Exam not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ExamViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            // check logged in user took this exam or not
            var user = _appService.GetAuthenticatedUser();
            if (user == null || !user.Exists())
                throw new ValidationException("User not found");

            var participant = await _examParticipantRepository
                .FirstOrDefaultAsync(x => x.Participant.TraineeId == user.Id && !x.IsDeleted, true);

            if (participant != null)
                throw new ValidationException("You already took this exam.");

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
            var selectSql = @"select e.Id, e.Name, b.Name BatchSchedule, cs.Name CourseSchedule, c.Name Course";

            var bodySql = @" from [training].[BatchScheduleAllocation] a
                left join [training].[Exam] e on e.BatchScheduleId = a.BatchScheduleId
                left join [training].[BatchSchedule] b on b.Id = a.BatchScheduleId
                left join [training].[CourseSchedule] cs on cs.Id = b.CourseScheduleId
                left join [training].[Course] c on c.Id = cs.CourseId
                where 
                a.TraineeId = @UserId and
                a.[Status] = 2 and
                a.IsDeleted = 0 and
                e.IsOnline = 0 and
                e.[Status] != 1 and
                convert(date, getutcdate()) = convert(date, e.ExamDate) and
                e.IsDeleted = 0";

            var pagingSql = @" order by e.UpdatedAt offset @Offset rows fetch next @Limit rows only";

            var countSql = "select count(*)" + bodySql;
            var resultSql = selectSql + bodySql + pagingSql;
            var @params = new
            {
                UserId = 1,
                Offset = pagingOptions.Offset,
                Limit = pagingOptions.Limit
            };

            var total = await _unitOfWork.GetConnection().ExecuteScalarAsync<int>(countSql, @params);
            var items = await _unitOfWork.GetConnection()
                .QueryAsync<MyExamListViewModel>(resultSql, @params);

            var result = new PagedCollection<MyExamListViewModel>(items, total, pagingOptions);

            return result;
        }

    }
}
