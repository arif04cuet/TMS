using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Module.Core.Shared;

namespace Module.Training.Data
{
    public class QuestionService : IQuestionService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<QuestionOption> _questionOptionRepository;
        private readonly IRepository<TopicQuestion> _topicQuestionRepository;



        public QuestionService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _questionRepository = _unitOfWork.GetRepository<Question>();
            _questionOptionRepository = _unitOfWork.GetRepository<QuestionOption>();
            _topicQuestionRepository = _unitOfWork.GetRepository<TopicQuestion>();

        }

        public async Task<long> CreateAsync(QuestionCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _questionRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            //save topics
            var topics = request.Topics.Select(x => new TopicQuestion
            {
                QuestionId = entity.Id,
                TopicId = x
            });
            await _topicQuestionRepository.AddRangeAsync(topics);

            //save options
            var options = request.Options.Select(x => new QuestionOption
            {
                IsCorrect = x.IsCorrect,
                Option = x.Option,
                QuestionId = entity.Id
            });

            await _questionOptionRepository.AddRangeAsync(options, cancellationToken);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(QuestionUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _questionRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Question not found");

            request.Map(entity);


            //update topics

            await _topicQuestionRepository.UpdateAsync(
                           request.Topics,
                           x => x.QuestionId == request.Id,
                           x => x.TopicId,
                           x => new TopicQuestion
                           {
                               QuestionId = request.Id,
                               TopicId = x
                           },
                           ids => x => ids.Contains(x.TopicId) && x.QuestionId == request.Id
                           );

            //update options

            foreach (var option in request.Options)
            {
                if (option.Id.HasValue)
                {
                    // update
                    var dbOption = await _questionOptionRepository
                        .Where(x => x.Id == option.Id.Value && !x.IsDeleted)
                        .FirstOrDefaultAsync(cancellationToken);
                    if (dbOption != null)
                    {
                        option.Map(dbOption);
                    }
                }
                else
                {
                    // new
                    var newOption = option.Map();
                    newOption.QuestionId = entity.Id;
                    await _questionOptionRepository.AddAsync(newOption);
                }
            }

            var requestOptionIds = request.Options.Where(x => x.Id.HasValue).Select(x => x.Id.Value);

            var optionToBeDeleted = await _questionOptionRepository
                .Where(x => x.QuestionId == entity.Id && !requestOptionIds.Contains(x.Id) && !x.IsDeleted)
                .ToListAsync();

            _questionOptionRepository.RemoveRange(optionToBeDeleted);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _questionRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Question not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<QuestionViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _questionRepository.GetAsync(x => x.Id == id, QuestionViewModel.Select(), cancellationToken);

            item.Options = await _questionOptionRepository
                .Where(x => x.QuestionId == item.Id && !x.IsDeleted)
                .Select(x => new QuestionOptionViewModel
                {
                    Id = x.Id,
                    IsCorrect = x.IsCorrect,
                    Option = x.Option
                })
                .ToListAsync(cancellationToken);


            //get topics
            item.Topics = await _topicQuestionRepository
                            .AsReadOnly()
                            .Where(x => x.QuestionId == id && !x.IsDeleted)
                            .Select(x => new IdNameViewModel
                            {
                                Id = x.TopicId,
                                Name = x.Topic.Name
                            })
                            .ToListAsync();

            return item;
        }

        public async Task<PagedCollection<QuestionViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _questionRepository.ListAsync(QuestionViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

    }
}
