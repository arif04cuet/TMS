using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface IMethodService : IScopedService
    {
        Task<long> CreateAsync(MethodCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(MethodUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<MethodViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<MethodViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
