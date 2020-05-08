using Infrastructure;
using Module.Asset.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface ICheckoutHistoryService : IScopedService
    {
        Task<long> CreateAsync(CheckoutHistoryCreateRequest request, CancellationToken cancellationToken = default);

        Task<PagedCollection<CheckoutHistoryListViewModel>> ListAsync(long itemId, AssetType itemType, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}
