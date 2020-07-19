using Infrastructure;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IAllocationService : IScopedService
    {
        Task<long> CreateAsync(AllocationCreateRequest request, CancellationToken cancellationToken = default);

        Task<long> UpdateAsync(AllocationUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<AllocationViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<AllocationViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<AllocationRentViewModel> GetRent(long allocationId, DateTime checkout, CancellationToken cancellationToken = default);

        Task<PagedCollection<IdNameViewModel>> ListBatchScheduleAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<long> GroupCheckoutByBatchScheduleAsync(AllocationGroupCheckoutByBatchScheduleRequest request, CancellationToken cancellationToken = default);

    }
}
