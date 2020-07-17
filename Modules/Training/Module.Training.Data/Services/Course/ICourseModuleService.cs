using Infrastructure;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface ICourseModuleService : IScopedService
    {
        Task<long> CreateAsync(CourseModuleCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(CourseModuleUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<CourseModuleViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<CourseModuleListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<CourseModuleTopicListViewModel>> ListTopicAsync(long courseModuleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<IdNameViewModel>> ListMethodAsync(long courseModuleId);

    }
}
