using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public interface ILibraryReportService : IScopedService
    {

        Task<PagedCollection<NewBookListViewModel>> ListNewBookAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<PagedCollection<LostBookListViewModel>> ListLostBookAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<PagedCollection<LibraryAtAGlanceListViewModel>> ListLibraryAtAGlanceAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<PagedCollection<BookIssueListViewModel>> ListIssueAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<PagedCollection<BookEntryListViewModel>> ListBookEntryAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);
    }
}
