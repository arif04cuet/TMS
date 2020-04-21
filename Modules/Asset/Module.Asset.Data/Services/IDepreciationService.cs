using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IDepreciationService : IScopedService
    {
        Task<long> CreateAsync(DepreciationCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(DepreciationUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<DepreciationViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<DepreciationViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);


    }
}
