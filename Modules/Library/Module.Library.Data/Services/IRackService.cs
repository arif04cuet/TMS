using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public interface IRackService : IScopedService
    {
        Task<long> CreateAsync(RackCreateRequest request, CancellationToken ct = default);

        Task<bool> DeleteAsync(long id, CancellationToken ct = default);

        Task<PagedCollection<RackListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<RackViewModel> GetAsync(long id);

        Task<bool> UpdateAsync(RackUpdateRequest request, CancellationToken ct = default);
    }
}
