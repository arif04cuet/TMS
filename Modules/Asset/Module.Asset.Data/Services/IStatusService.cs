using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IStatusService : IScopedService
    {
        Task<long> CreateAsync(StatusCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(StatusUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<StatusViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<StatusViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        PagedCollection<object> MasterStatuses(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

    }
}
