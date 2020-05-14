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
    public class AssetAuditService : IAssetAuditService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AssetAudit> _assetAuditRepository;
        private readonly IRepository<Entities.Asset> _assetRepository;

        public AssetAuditService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _assetAuditRepository = _unitOfWork.GetRepository<AssetAudit>();
            _assetRepository = _unitOfWork.GetRepository<Entities.Asset>();
        }

        public async Task<long> CreateAsync(AssetAuditCreateRequest request, CancellationToken cancellationToken = default)
        {
            var asset = await _assetRepository
                .FirstOrDefaultAsync(x => x.AssetTag == request.AssetTag && !x.IsDeleted, true);

            if (asset == null)
                throw new NotFoundException("Asset not found");

            var newEntity = request.ToMap();
            newEntity.AssetId = asset.Id;
            await _assetAuditRepository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newEntity.Id;
        }

        public async Task<bool> UpdateAsync(AssetAuditUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _assetAuditRepository.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Asset audit not found");

            entity = request.ToMap(entity);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _assetAuditRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Asset audit not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<AssetAuditViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var result = await _assetAuditRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new AssetAuditViewModel
                {
                    Id = x.Id,
                    Asset = x.AssetId != null ? new IdNameViewModel
                    {
                        Id = x.Asset.Id,
                        Name = x.Asset.Name
                    } : null,
                    AuditDate = x.AuditDate,
                    NextAuditDate = x.NextAuditDate,
                    Note = x.Note
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Asset audit not found");

            return result;
        }

        public async Task<PagedCollection<AssetAuditViewModel>> ListAsync(long assetId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _assetAuditRepository
                .AsReadOnly()
                .Where(x => x.AssetId == assetId && !x.IsDeleted)
                .ApplySearch(searchOptions);

            return await ListAsync(itemsQuery, pagingOptions, searchOptions, cancellationToken); ;
        }

        public async Task<PagedCollection<AssetAuditViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _assetAuditRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            return await ListAsync(itemsQuery, pagingOptions, searchOptions, cancellationToken);
        }

        private async Task<PagedCollection<AssetAuditViewModel>> ListAsync(IQueryable<AssetAudit> itemsQuery, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new AssetAuditViewModel
                {
                    Id = x.Id,
                    Asset = x.AssetId != null ? new IdNameViewModel
                    {
                        Id = x.Asset.Id,
                        Name = x.Asset.Name
                    } : null,
                    AuditDate = x.AuditDate,
                    NextAuditDate = x.NextAuditDate,
                    Note = x.Note
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<AssetAuditViewModel>(items, total, pagingOptions);
            return result;
        }
    }
}
