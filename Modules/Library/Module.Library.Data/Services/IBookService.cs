using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public interface IBookService : IScopedService
    {
        Task<long> CreateAsync(BookCreateRequest request, CancellationToken ct = default);

        Task<bool> DeleteAsync(long id, CancellationToken ct = default);

        Task<PagedCollection<BookListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<BookViewModel> GetAsync(long id);

        Task<bool> UpdateAsync(BookUpdateRequest request, CancellationToken ct = default);
    }
}
