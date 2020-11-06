using Infrastructure;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public interface ILibraryReportService : IScopedService
    {

        Task<PagedCollection<NewBookListViewModel>> ListNewBookAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<PagedCollection<LostBookListViewModel>> ListLostBooksAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<PagedCollection<LibraryAtAGlanceListViewModel>> ListLibraryAtAGlanceAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<PagedCollection<BookIssueListViewModel>> ListIssueAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<PagedCollection<BookEntryListViewModel>> ListBookEntryAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default);

        Task<List<NewBookListViewModel>> ExportNewBooksAsync();

        Task<List<LostBookListViewModel>> ExportLostBooksAsync();

        Task<IEnumerable<LibraryAtAGlanceListViewModel>> ExportLibraryAtAGlanceAsync();

        Task<IEnumerable<BookEntryListViewModel>> ExportBookEntryAsync();

        Task<List<BookIssueListViewModel>> ExportIssuesAsync();
    }
}
