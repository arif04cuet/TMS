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
    [Route("api/books/reservations")]
    [ApiController]
    public class BookReservationController : ControllerBase
    {

        private readonly IBookReservationService _bookReservationService;

        public BookReservationController(
            IBookReservationService bookReservationService)
        {
            _bookReservationService = bookReservationService;
        }

        [HttpGet]
        [RequirePermission(BookReservationList, BookReservationManage)]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery] SearchOptions searchOptions)
        {
            var result = await _bookReservationService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("assignable-book-items")]
        public async Task<ActionResult> ListAssignableBookItems([FromQuery] PagingOptions pagingOptions, [FromQuery] SearchOptions searchOptions)
        {
            var result = await _bookReservationService.ListAssignableBookItemsAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequirePermission(BookReservationView, BookReservationManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _bookReservationService.GetAsync(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(BookReservationCreate, BookReservationManage)]
        public async Task<IActionResult> Post([FromBody] BookReservationCreateRequest request)
        {
            var result = await _bookReservationService.CreateAsync(request);
            return result.ToCreatedResult($"api/books/reservations/{result}");
        }

        [HttpPut("{id}")]
        [RequirePermission(BookReservationUpdate, BookReservationManage)]
        public async Task<IActionResult> Put(long id, [FromBody] BookReservationUpdateRequest request)
        {
            request.Id = id;
            var result = await _bookReservationService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(BookReservationDelete, BookReservationManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _bookReservationService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/cancel")]
        [RequirePermission(BookReservationDelete, BookReservationManage)]
        public async Task<IActionResult> Cancel(long id)
        {
            await _bookReservationService.CancelAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/issue")]
        [RequirePermission(BookReservationDelete, BookReservationManage)]
        public async Task<IActionResult> Issue(long id)
        {
            await _bookReservationService.IssueAsync(id);
            return NoContent();
        }

    }
}
