using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IAccessoryService : IScopedService
    {
        Task<long> CreateAsync(AccessoryCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(AccessoryUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<AccessoryViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<AccessoryViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<AccessoryCheckoutListViewModel>> ListCheckoutAsync(long accessoryId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<bool> CheckoutAsync(AccessoryCheckoutRequest request, CancellationToken cancellationToken = default);

        Task<bool> CheckinAsync(AccessoryCheckinRequest request, CancellationToken cancellationToken = default);
    }
}
