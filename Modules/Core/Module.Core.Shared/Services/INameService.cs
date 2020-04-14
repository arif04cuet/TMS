using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Shared
{
    public interface INameService<T>
    {
        Task<IdNameViewModel> Get(long id, CancellationToken cancellationToken = default);

        Task<PagedCollection<IdNameViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);
    }
}
