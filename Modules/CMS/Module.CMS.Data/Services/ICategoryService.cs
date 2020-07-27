using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.CMS.Data
{
    public interface ICategoryService : IScopedService
    {
        Task<long> CreateAsync(CategoryCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(CategoryUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<CategoryViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<CategoryViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
