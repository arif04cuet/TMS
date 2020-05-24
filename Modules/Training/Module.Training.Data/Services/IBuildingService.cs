using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IBuildingService : IScopedService
    {
        Task<long> CreateAsync(BuildingCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(BuildingUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<BuildingViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<BuildingViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
