using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IExpertiseService : IScopedService
    {
        Task<long> CreateAsync(ExpertiseCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ExpertiseUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<ExpertiseViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<ExpertiseViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
