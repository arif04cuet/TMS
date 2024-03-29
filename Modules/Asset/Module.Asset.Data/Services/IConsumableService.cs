﻿using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IConsumableService : IScopedService
    {
        Task<long> CreateAsync(ConsumableCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ConsumableUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<ConsumableViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<ConsumableViewModel>> ListAsync(long? itemCodeId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<ConsumableCheckoutListViewModel>> ListCheckoutAsync(long accessoryId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<ConsumableCheckoutListViewModel>> ListCheckoutByItemCodeAsync(long itemCodeId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<bool> CheckoutAsync(ConsumableCheckoutRequest request, CancellationToken cancellationToken = default);

        Task<bool> CheckoutByItemCodeAsync(ConsumableCheckoutByItemCodeRequest request, CancellationToken cancellationToken = default);

        Task<bool> CheckinAsync(ConsumableCheckinRequest request, CancellationToken cancellationToken = default);

        Task<PagedCollection<ConsumableListGroupByItemCodeViewModel>> ListGroupByItemCodeAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<ConsumableCheckoutViewModel> GetCheckoutAsync(long checkoutId, CancellationToken cancellationToken = default);
    }
}
