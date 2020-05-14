using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IAssetAuditService : IScopedService
    {
        Task<long> CreateAsync(AssetAuditCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(AssetAuditUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<AssetAuditViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<AssetAuditViewModel>> ListAsync(long assetId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<AssetAuditViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}
