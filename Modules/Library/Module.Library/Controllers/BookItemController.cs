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
    [Route("api/books/items")]
    [ApiController]
    public class BookItemController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookItemController(
            IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [RequirePermission(BookList, BookManage)]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _bookService.ListBookItemsAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequirePermission(BookView, BookManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _bookService.GetBookItemAsync(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(BookCreate, BookManage)]
        public async Task<IActionResult> Post([FromBody] BookItemCreateRequest request)
        {
            var result = await _bookService.CreateBookItemAsync(request);
            return result.ToCreatedResult($"api/books/{result}");
        }

        [HttpPut("{id}")]
        [RequirePermission(BookUpdate, BookManage)]
        public async Task<IActionResult> Put(long id, [FromBody] BookItemUpdateRequest request)
        {
            request.Id = id;
            var result = await _bookService.UpdateBookItemAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(BookDelete, BookManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _bookService.DeleteBookItemAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/issue")]
        [RequirePermission(BookCreate, BookManage)]
        public async Task<IActionResult> Issue(long id, [FromBody] BookItemIssueRequest request)
        {
            request.BookItem = id;
            var result = await _bookService.IssueBookItemAsync(request);
            return result.ToOkResult();
        }

        [HttpGet("{id}/issue")]
        [RequirePermission(BookCreate, BookManage)]
        public async Task<IActionResult> GetIssue(long id)
        {
            var result = await _bookService.GetIssueAsync(id);
            return result.ToOkResult();
        }

        [HttpPost("{id}/return")]
        [RequirePermission(BookCreate, BookManage)]
        public async Task<IActionResult> Return(long id, [FromBody] BookItemReturnRequest request)
        {
            request.BookItem = id;
            var result = await _bookService.ReturnBookItemAsync(request);
            return result.ToOkResult();
        }

    }
}
