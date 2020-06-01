using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface ICourseCategoryService : IScopedService
    {
        Task<long> CreateAsync(CourseCategoryCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(CourseCategoryUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<CourseCategoryViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<CourseCategoryViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
