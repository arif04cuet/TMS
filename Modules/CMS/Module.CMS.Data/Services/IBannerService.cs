using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.CMS.Data
{
    public interface IBannerService : IScopedService
    {
        Task<long> CreateAsync(BannerCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(BannerUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<BannerViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<BannerViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
