using Infrastructure;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface ICourseScheduleService : IScopedService
    {
        Task<long> CreateAsync(CourseScheduleCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(CourseScheduleUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<CourseScheduleViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<CourseScheduleViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<IdNameViewModel>> BudgetListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
