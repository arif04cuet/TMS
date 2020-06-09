using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class AssetModelService : IAssetModelService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AssetModel> _assetModelRepository;

        public AssetModelService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _assetModelRepository = _unitOfWork.GetRepository<AssetModel>();

        }

        public async Task<long> CreateAsync(AssetModelCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newEntity = request.ToMap();
            await _assetModelRepository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(AssetModelUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _assetModelRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Asset model not found");

            entity = request.ToMap(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _assetModelRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Asset model not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<AssetModelViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var result = await _assetModelRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new AssetModelViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = new IdNameViewModel { Id = x.CategoryId,  Name = x.Category.Name },
                    IsRequestable = x.IsRequestable,
                    Manufacturer = new IdNameViewModel { Id = x.ManufacturerId, Name = x.Manufacturer.Name },
                    ModelNo = x.ModelNo,
                    Note = x.Note
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Asset model not found");

            return result;
        }
        
        public async Task<PagedCollection<AssetModelViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _assetModelRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new AssetModelViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = new IdNameViewModel { Id = x.CategoryId, Name = x.Category.Name },
                    IsRequestable = x.IsRequestable,
                    Manufacturer = new IdNameViewModel { Id = x.ManufacturerId, Name = x.Manufacturer.Name },
                    ModelNo = x.ModelNo,
                    Note = x.Note
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<AssetModelViewModel>(items, total, pagingOptions);
            return result;
        }
    }
}
