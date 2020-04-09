using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Core.ViewModels;
using System.Threading.Tasks;

using static Module.Core.Data.PermissionConstants;
using Module.Library.Services;
using Module.Library.ViewModels;

namespace Module.Library.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class LibraryController : ControllerBase
    {

        private readonly IBookService _bookService;

        public LibraryController(
            IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [RequirePermission(BookList)]
        [Authorize]
        public async Task<ActionResult> Gets()
        {
            var result = await _bookService.ListAsync();
            return Ok(new Response(result));
        }

        [HttpGet("{id}")]
        [RequirePermission(BookView)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _bookService.GetAsync(id);
            return Ok(new Response(result));
        }

        [HttpPost]
        [RequirePermission(BookCreate)]
        public async Task<IActionResult> Post([FromBody] BookCreateRequest request)
        {
            var result = await _bookService.CreateAsync(request);
            return Created("", new Response(result));
        }

        [HttpPut("{id}")]
        [RequirePermission(BookUpdate)]
        public async Task<IActionResult> Put(long id, [FromBody] BookUpdateRequest request)
        {
            request.Id = id;
            var result = await _bookService.UpdateAsync(request);
            return Ok(new Response(result));
        }

        [HttpDelete("{id}")]
        [RequirePermission(BookDelete)]
        public async Task<IActionResult> Delete(long id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }

    }
}
