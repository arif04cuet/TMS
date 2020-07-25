using Dapper;
using Infrastructure;
using Infrastructure.Data;
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

        public MyExamService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public async Task<PagedCollection<ExamViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _examRepository.ListAsync(ExamViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<ExamParticipantViewRequest>> ListParticipantAsync(long batchScheduleId, long examId)
        {
            var sqlWithExam = $@"select ep.Id, isnull(ep.Mark, 0) Mark, u.FullName Name, a.Id ParticipantId
                    from [training].[BatchScheduleAllocation] a
                    left join [training].[ExamParticipant] ep on ep.ParticipantId = a.Id
                    left join [core].[User] u on u.Id = a.TraineeId
                    where a.[Status] = 2 and a.BatchScheduleId = ${batchScheduleId} and ep.ExamId = ${examId}";

            var items = await _dbConnection.QueryAsync<ExamParticipantViewRequest>(sqlWithExam);

            if (items.Count() <= 0)
            {
                // no exam participants
                var allParticipantsSql = $@"select null Id, 0 Mark, u.FullName Name,                  a.Id ParticipantId
                                from [training].[BatchScheduleAllocation] a
                                left join [core].[User] u on u.Id = a.TraineeId
                                where a.[Status] = 2 and a.BatchScheduleId = ${batchScheduleId}";

                items = await _dbConnection.QueryAsync<ExamParticipantViewRequest>(allParticipantsSql);
            }

            var pagingOptions = new PagingOptions
            {
                Limit = items.Count(),
                Offset = 0
            };
            var result = new PagedCollection<ExamParticipantViewRequest>(items, items.Count(), pagingOptions);
            return result;
        }

        public async Task<long> UpdateMarksAsync(ExamMarkUpdateRequest request, CancellationToken cancellationToken = default)
        {

            foreach (var mark in request.Marks)
            {
                if (mark.ParticipantId == default)
                    throw new ValidationException("Invalid participant.");

                if (mark.Id.HasValue)
                {
                    // update
                    var entity = await _examParticipantRepository
                        .FirstOrDefaultAsync(x => x.Id == mark.Id.Value && x.ExamId == request.Exam && !x.IsDeleted);

                    if (entity == null)
                        throw new ValidationException("Invalid participant.");

                    entity.Mark = mark.Mark;
                }
            }

            var newExamMarks = request
                .Marks
                .Where(x => !x.Id.HasValue)
                .Select(x => new ExamParticipant
                {
                    ExamId = request.Exam,
                    Mark = x.Mark,
                    ParticipantId = x.ParticipantId,
                });

            await _examParticipantRepository.AddRangeAsync(newExamMarks, cancellationToken);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }

    }
}
