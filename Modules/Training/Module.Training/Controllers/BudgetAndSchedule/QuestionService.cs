using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class QuestionService /*: IQuestionService*/
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<QuestionOption> _questionOptionRepository;

        public QuestionService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _questionRepository = _unitOfWork.GetRepository<Question>();
            _questionOptionRepository = _unitOfWork.GetRepository<QuestionOption>();
        }

        public async Task<long> CreateAsync(QuestionCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _questionRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

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

            foreach (var option in request.Options)
            {
                // var dbOptions
            }

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _questionRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Grade not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        //public async Task<GradeViewModel> Get(long id, CancellationToken cancellationToken = default)
        //{
        //    var item = await _questionRepository
        //        .AsReadOnly()
        //        .Where(x => x.Id == id && !x.IsDeleted)
        //        .Select(x => GradeViewModel.Map(x))
        //        .FirstOrDefaultAsync();

        //    if (item == null)
        //        throw new NotFoundException("Grade not found");

        //    return item;
        //}

        //public async Task<PagedCollection<GradeViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        //{
        //    var hostels = _questionRepository
        //        .AsReadOnly()
        //        .Where(x => !x.IsDeleted)
        //        .ApplySearch(searchOptions)
        //        .ApplyPagination(pagingOptions);

        //    var results = hostels.Select(x => GradeViewModel.Map(x));

        //    var total = await hostels.Select(x => x.Id).CountAsync(cancellationToken);
        //    var items = await results.ToListAsync(cancellationToken);

        //    var result = new PagedCollection<GradeViewModel>(items, total, pagingOptions);
        //    return result;
        //}

    }
}
