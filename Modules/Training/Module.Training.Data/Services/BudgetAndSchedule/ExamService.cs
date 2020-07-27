using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Shared;
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
    public class ExamService : IExamService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IPdfConverter _pdfConverter;
        private readonly IRazorViewRenderer _viewRenderer;
        private readonly IRepository<Exam> _examRepository;
        private readonly IRepository<ExamParticipant> _examParticipantRepository;
        private readonly IRepository<ExamQuestion> _examQuestionRepository;
        private readonly IDbConnection _dbConnection;

        public ExamService(
            IUnitOfWork unitOfWork,
            IPdfConverter pdfConverter,
            IRazorViewRenderer viewRenderer)
        {
            _unitOfWork = unitOfWork;
            _pdfConverter = pdfConverter;
            _viewRenderer = viewRenderer;
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

        public async Task<PagedCollection<ExamViewModel>> ListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _examRepository.ListAsync(x => x.BatchScheduleId == batchScheduleId, ExamViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<ExamResultViewModel>> ListParticipantAsync(long batchScheduleId, long examId)
        {
            var query = _examParticipantRepository
                .Where(x => x.ExamId == examId
                && x.Participant.BatchScheduleId == batchScheduleId
                && !x.IsDeleted)
                .Select(x => new ExamResultViewModel
                {
                    //AllocationId = x.ParticipantId.Value,
                    Id = x.Id,
                    ParticipantId = x.ParticipantId.Value,
                    Name = x.Participant.Trainee.FullName,
                    TotalMark = x.Mark,
                    IsMcq = x.Exam.QuestionType == QuestionType.MCQ
                });

            var items = await query.ToListAsync();
            var total = items.Count();

            var pagingOptions = new PagingOptions
            {
                Limit = total,
                Offset = 0
            };
            var result = new PagedCollection<ExamResultViewModel>(items, total, pagingOptions);
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

        public async Task<byte[]> DownloadExamPaperAsync(long examId, CancellationToken cancellationToken = default)
        {
            var examPapper = await _examRepository
                .AsReadOnly()
                .Where(x => x.Id == examId && !x.IsDeleted)
                .Select(ExamPaperPdfModel.Select())
                .FirstOrDefaultAsync();

            if (examPapper == null)
                throw new ValidationException("Exam papper not found");

            examPapper.Questions = await _unitOfWork.GetRepository<ExamQuestion>()
                    .AsReadOnly()
                    .Where(x => x.ExamId == examId && !x.IsDeleted)
                    .Select(QuestionPdfModel.Select())
                    .ToListAsync(cancellationToken);

            var htmlContent = await _viewRenderer.RenderViewToStringAsync("/Views/exam-paper.cshtml", examPapper);
            var bytes = _pdfConverter.Convert(htmlContent);
            return bytes;
        }

        public async Task<ExamAnswerViewModel> ViewExamAnswerAsync(long allocationId, long examId, CancellationToken cancellationToken = default)
        {
            var exam = await _examRepository
                .AsReadOnly()
                .Where(x => x.Id == examId && !x.IsDeleted)
                .Select(x => new { Id = x.Id, Name = x.Name })
                .FirstOrDefaultAsync();

            if (exam == null)
                throw new ValidationException("Exam not found");

            var questions = await _unitOfWork.GetRepository<ExamQuestion>()
                    .AsReadOnly()
                    .Where(x => x.ExamId == examId && !x.IsDeleted)
                    .Select(x => new ExamAnswerQuestionViewModel
                    {
                        Id = x.QuestionId,
                        Name = x.Question.Title,
                        Options = x.Question.Options.Select(y => new IdNameViewModel
                        {
                            Id = y.Id,
                            Name = y.Option
                        })
                    })
                    .ToListAsync(cancellationToken);

            foreach (var question in questions)
            {
                var ans = await _unitOfWork.GetRepository<ExamAnswer>()
                    .AsReadOnly()
                    .Where(x => x.ExamId == examId
                    && x.QuestionId == question.Id
                    && x.AllocationId == allocationId
                    && !x.IsDeleted)
                    .FirstOrDefaultAsync(cancellationToken);

                if (ans != null)
                {
                    question.WrittenAnswer = ans.WrittenAnswer;
                    question.McqAnswer = ans.McqAnswerId;
                }
            }

            return new ExamAnswerViewModel
            {
                Id = exam.Id,
                Name = exam.Name,
                Questions = questions
            };
        }

    }
}
