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
    public class ResourcePersonService : IResourcePersonService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ResourcePerson> _resourcePersonRepository;
    
        public ResourcePersonService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _resourcePersonRepository = _unitOfWork.GetRepository<ResourcePerson>();
        }

        public async Task<long> CreateAsync(ResourcePersonCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _resourcePersonRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(ResourcePersonUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _resourcePersonRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Resource person not found");

            request.Map(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _resourcePersonRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Resource person not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ResourcePersonViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _resourcePersonRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => ResourcePersonViewModel.Map(x))
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Resource person not found");

            return item;
        }

        public async Task<PagedCollection<ResourcePersonViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var hostels = _resourcePersonRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = hostels.Select(x => ResourcePersonViewModel.Map(x));

            var total = await hostels.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<ResourcePersonViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
