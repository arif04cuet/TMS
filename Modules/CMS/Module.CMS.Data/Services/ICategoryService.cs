using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.CMS.Data
{
    public interface ICategoryService : IScopedService
    {
        Task<long> CreateAsync(CmsCategoryCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(CmsCategoryUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<CmsCategoryViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<CmsCategoryViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
