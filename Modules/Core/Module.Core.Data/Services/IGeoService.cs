
using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IGeoService : IScopedService
    {

        Task<PagedCollection<GeoViewModel>> ListDistrictAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
        Task<PagedCollection<GeoViewModel>> ListUpazilaAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}

