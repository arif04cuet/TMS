using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface ICourseService : IScopedService
    {
        Task<long> CreateAsync(CourseCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(CourseUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<CourseViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<CourseViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
