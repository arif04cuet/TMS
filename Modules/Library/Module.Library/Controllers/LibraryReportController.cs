using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Library.Data;
using System.Threading.Tasks;
using Module.Core.Shared;

using static Module.Core.Shared.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;

namespace Module.Library.Controllers
{
    [Route("api/library/reports")]
    [ApiController]
    public class LibraryReportController : ControllerBase
    {

        private readonly ILibraryReportService _libraryReportService;

        public LibraryReportController(
            ILibraryReportService libraryReportService)
        {
            _libraryReportService = libraryReportService;
        }

        [HttpGet("issues")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ListIssue([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryReportService.ListIssueAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("book-entries")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ListEntries([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryReportService.ListBookEntryAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("at-a-glance")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ListAtAGlance([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryReportService.ListLibraryAtAGlanceAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("lost-books")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ListLostBook([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryReportService.ListLostBookAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("new-books")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ListNewBook([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryReportService.ListNewBookAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }
    }
}
