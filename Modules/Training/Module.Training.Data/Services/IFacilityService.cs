using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IFacilityService : IScopedService
    {
        Task<long> CreateAsync(FacilityCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(FacilityUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<FacilityViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<FacilityViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}
