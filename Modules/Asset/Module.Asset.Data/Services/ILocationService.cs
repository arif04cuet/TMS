using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface ILocationService : IScopedService
    {
        Task<long> CreateAsync(LocationCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(LocationUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<LocationViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<LocationViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);


    }
}
