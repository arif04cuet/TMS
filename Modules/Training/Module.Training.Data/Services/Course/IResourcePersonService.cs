using Infrastructure;
using Module.Core.Shared;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IResourcePersonService : IScopedService
    {
        Task<long> CreateAsync(ResourcePersonCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ResourcePersonUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<ResourcePersonViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<ResourcePersonViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

        Task<PagedCollection<IdNameViewModel>> ListAssignableUsersAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
