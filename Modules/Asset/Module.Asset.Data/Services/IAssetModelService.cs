using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IAssetModelService : IScopedService
    {
        Task<long> CreateAsync(AssetModelCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(AssetModelUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<AssetModelViewModel> Get(long Id, CancellationToken cancellationToken = default);

        //Task<LicenseViewModel> GetDetails(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<AssetModelViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}
