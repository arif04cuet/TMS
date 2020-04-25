using Infrastructure;
using Module.Core.Shared;
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

        Task<long> CreateBookItemAsync(BookItemCreateRequest request, CancellationToken ct = default);

        Task<long> UpdateBookItemAsync(BookItemUpdateRequest request, CancellationToken ct = default);

        Task<bool> DeleteBookItemAsync(long bookItemId, CancellationToken ct = default);

        Task<BookItemViewModel> GetBookItemAsync(long bookItemId);

        Task<PagedCollection<BookItemListViewModel>> ListBookItemsAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<PagedCollection<IdNameViewModel>> ListBookEditionsAsync(long bookId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<long> IssueBookItemAsync(BookItemIssueRequest request, CancellationToken ct = default);

        Task<bool> ReturnBookItemAsync(BookItemReturnRequest request, CancellationToken ct = default);

        Task<BookItemIssueViewModel> GetIssueAsync(long bookItemId);

        Task<PagedCollection<BookIssueListViewModel>> ListIssueAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);
    }
}
