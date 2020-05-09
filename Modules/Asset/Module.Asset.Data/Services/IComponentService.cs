using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IComponentService : IScopedService
    {
        Task<long> CreateAsync(ComponentCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ComponentUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<ComponentViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<ComponentViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<ComponentCheckoutListViewModel> GetCheckoutAsync(long checkoutId, CancellationToken cancellationToken = default);

        Task<PagedCollection<ComponentCheckoutListViewModel>> ListCheckoutAsync(long accessoryId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<bool> CheckoutAsync(ComponentCheckoutRequest request, CancellationToken cancellationToken = default);

        Task<bool> CheckinAsync(ComponentCheckinRequest request, CancellationToken cancellationToken = default);
    }
}
