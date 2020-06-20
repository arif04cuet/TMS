using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IClassRoutineService : IScopedService
    {
        Task<long> CreateAsync(ClassRoutineCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ClassRoutineUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default);

        Task<ClassRoutineViewModel> Get(long classRoutineId, CancellationToken cancellationToken = default);

        Task<PagedCollection<ClassRoutineViewModel>> ListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
