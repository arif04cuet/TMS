using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IOfficeService : IScopedService
    {
        Task<long> CreateAsync(OfficeCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);

        Task<OfficeViewModel> Get(long id, CancellationToken cancellationToken = default);

        Task<PagedCollection<OfficeListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(OfficeUpdateRequest request, CancellationToken cancellationToken = default);
    }
}
