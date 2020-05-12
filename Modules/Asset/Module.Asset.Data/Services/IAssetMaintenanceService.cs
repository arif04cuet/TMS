using Infrastructure;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IAssetMaintenanceService : IScopedService
    {
        Task<long> CreateAsync(AssetMaintenanceCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(AssetMaintenanceUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<AssetMaintenanceViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<AssetMaintenanceViewModel>> ListAsync(long assetId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<AssetMaintenanceViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        PagedCollection<IdNameViewModel> ListTypes(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);
    }
}
