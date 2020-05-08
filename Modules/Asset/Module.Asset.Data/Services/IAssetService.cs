using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IAssetService : IScopedService
    {
        Task<long> CreateAsync(AssetCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(AssetUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<AssetViewModel> Get(long Id, CancellationToken cancellationToken = default);

        //Task<LicenseViewModel> GetDetails(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<AssetViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}
