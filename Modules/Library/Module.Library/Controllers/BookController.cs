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
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(
            IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _bookService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequirePermission(BookView, BookManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _bookService.GetAsync(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(BookCreate, BookManage)]
        public async Task<IActionResult> Post([FromBody] BookCreateRequest request)
        {
            var result = await _bookService.CreateAsync(request);
            return result.ToCreatedResult($"api/books/{result}");
        }

        [HttpPut("{id}")]
        [RequirePermission(BookUpdate, BookManage)]
        public async Task<IActionResult> Put(long id, [FromBody] BookUpdateRequest request)
        {
            request.Id = id;
            var result = await _bookService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(BookDelete, BookManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }

        // Book Editions
        [HttpGet("{bookId}/editions")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ListBookEditions(long bookId, [FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _bookService.ListBookEditionsAsync(bookId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("issues")]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> ListIssue([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _bookService.ListIssueAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }
    }
}
