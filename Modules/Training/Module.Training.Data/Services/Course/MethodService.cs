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
    public class MethodService : IMethodService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Method> _methodRepository;
    
        public MethodService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _methodRepository = _unitOfWork.GetRepository<Method>();
        }

        public async Task<long> CreateAsync(MethodCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _methodRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(MethodUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _methodRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Method not found");

            request.Map(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _methodRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Method not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<MethodViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _methodRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => MethodViewModel.Map(x))
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Method not found");

            return item;
        }

        public async Task<PagedCollection<MethodViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var hostels = _methodRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = hostels.Select(x => MethodViewModel.Map(x));

            var total = await hostels.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<MethodViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
