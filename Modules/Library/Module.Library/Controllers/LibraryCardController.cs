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
    [Route("api/libraries/cards")]
    [ApiController]
    public class LibraryCardController : ControllerBase
    {

        private readonly ILibraryCardService _libraryCardService;

        public LibraryCardController(
            ILibraryCardService libraryCardService)
        {
            _libraryCardService = libraryCardService;
        }

        [HttpGet]
        [RequirePermission(LibraryList, LibraryManage)]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryCardService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("types")]
        [RequirePermission(LibraryList, LibraryManage)]
        public async Task<ActionResult> ListCardTypes([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryCardService.ListCardTypesAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequirePermission(LibraryView, LibraryManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _libraryCardService.GetAsync(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(LibraryCreate, LibraryManage)]
        public async Task<IActionResult> Post([FromBody] LibraryCardCreateRequest request)
        {
            var result = await _libraryCardService.CreateAsync(request);
            return result.ToCreatedResult($"api/libraries/{result}");
        }

        [HttpPut("{id}")]
        [RequirePermission(BookUpdate, BookManage)]
        public async Task<IActionResult> Put(long id, [FromBody] LibraryCardUpdateRequest request)
        {
            request.Id = id;
            var result = await _libraryCardService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(LibraryDelete, LibraryManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _libraryCardService.DeleteAsync(id);
            return NoContent();
        }

    }
}
