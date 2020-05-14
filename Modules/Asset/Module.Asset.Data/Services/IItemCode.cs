using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public interface IItemCodeService : IScopedService
    {
        Task<long> CreateAsync(ItemCodeCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(ItemCodeUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<ItemCodeViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<ItemCodeViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}
