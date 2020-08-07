using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.CMS.Data
{
    public interface IFaqService : IScopedService
    {
        Task<long> CreateAsync(FaqCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(FaqUpdateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default);

        Task<FaqViewModel> Get(long Id, CancellationToken cancellationToken = default);

        Task<PagedCollection<FaqViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default);

    }
}
