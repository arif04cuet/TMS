using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class ItemCodeService : IItemCodeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ItemCode> _repository;

        public ItemCodeService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<ItemCode>();
        }

        public async Task<long> CreateAsync(ItemCodeCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = request.ToMap();

            await _repository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(ItemCodeUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"ItemCode not found");

            entity = request.ToMap(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            ItemCode entity = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("ItemCode not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ItemCodeViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var result = await _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new ItemCodeViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    CategoryId = x.CategoryId,
                    MinQuantity = x.MinQuantity,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("ItemCode not found");

            return result;
        }

        public async Task<PagedCollection<ItemCodeViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new ItemCodeViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    CategoryId = x.CategoryId,
                    MinQuantity = x.MinQuantity,
                    IsActive = x.IsActive,
                    Category = x.Category
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<ItemCodeViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
