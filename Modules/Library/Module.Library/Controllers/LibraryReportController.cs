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
        private readonly IExcelService _excelService;

        public LibraryReportController(
            ILibraryReportService libraryReportService,
            IExcelService excelService)
        {
            _libraryReportService = libraryReportService;
            _excelService = excelService;
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
            var result = await _libraryReportService.ListLostBooksAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("new-books")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ListNewBook([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryReportService.ListNewBookAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpPost("issues/export")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ExportIssue()
        {
            var result = await _libraryReportService.ExportIssuesAsync();
            var bytes = _excelService.Generate(result);
            return bytes.ToCsvResult(HttpContext, $"export-issues.csv");
        }

        [HttpPost("book-entries/export")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ExportEntries()
        {
            var result = await _libraryReportService.ExportBookEntryAsync();
            var bytes = _excelService.Generate(result);
            return bytes.ToCsvResult(HttpContext, $"export-book-entries.csv");
        }

        [HttpPost("at-a-glance/export")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ExportAtAGlance()
        {
            var result = await _libraryReportService.ExportLibraryAtAGlanceAsync();
            var bytes = _excelService.Generate(result);
            return bytes.ToCsvResult(HttpContext, $"export-at-a-glance.csv");
        }

        [HttpPost("lost-books/export")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ExportLostBook()
        {
            var result = await _libraryReportService.ExportLostBooksAsync();
            var bytes = _excelService.Generate(result);
            return bytes.ToCsvResult(HttpContext, $"export-lost-books.csv");
        }

        [HttpPost("new-books/export")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ExportNewBook()
        {
            var result = await _libraryReportService.ExportNewBooksAsync();
            var bytes = _excelService.Generate(result);
            return bytes.ToCsvResult(HttpContext, $"export-new-books.csv");
        }
    }
}
