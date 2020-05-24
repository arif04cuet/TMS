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
    public class EvaluationMethodService : IEvaluationMethodService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EvaluationMethod> _evaluationMethodRepository;
    
        public EvaluationMethodService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _evaluationMethodRepository = _unitOfWork.GetRepository<EvaluationMethod>();
        }

        public async Task<long> CreateAsync(EvaluationMethodCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _evaluationMethodRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(EvaluationMethodUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _evaluationMethodRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Evaluation method not found");

            request.Map(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _evaluationMethodRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Evaluation method not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<EvaluationMethodViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _evaluationMethodRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => EvaluationMethodViewModel.Map(x))
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Evaluation method not found");

            return item;
        }

        public async Task<PagedCollection<EvaluationMethodViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var hostels = _evaluationMethodRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = hostels.Select(x => EvaluationMethodViewModel.Map(x));

            var total = await hostels.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<EvaluationMethodViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
