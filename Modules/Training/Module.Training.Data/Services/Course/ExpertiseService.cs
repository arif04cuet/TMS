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
    public class ExpertiseService : IExpertiseService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Expertise> _expertiseRepository;
    
        public ExpertiseService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _expertiseRepository = _unitOfWork.GetRepository<Expertise>();
        }

        public async Task<long> CreateAsync(ExpertiseCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _expertiseRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(ExpertiseUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _expertiseRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Expertise not found");

            request.Map(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _expertiseRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Expertise not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ExpertiseViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _expertiseRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => ExpertiseViewModel.Map(x))
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Expertise not found");

            return item;
        }

        public async Task<PagedCollection<ExpertiseViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var hostels = _expertiseRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = hostels.Select(x => ExpertiseViewModel.Map(x));

            var total = await hostels.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<ExpertiseViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
