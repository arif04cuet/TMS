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
    [Route("api/libraries")]
    [ApiController]
    public class LibraryController : ControllerBase
    {

        private readonly ILibraryService _libraryService;

        public LibraryController(
            ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        [RequirePermission(LibraryList, LibraryManage)]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequirePermission(LibraryView, LibraryManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _libraryService.GetAsync(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(LibraryCreate, LibraryManage)]
        public async Task<IActionResult> Post([FromBody] LibraryCreateRequest request)
        {
            var result = await _libraryService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        [RequirePermission(BookUpdate, BookManage)]
        public async Task<IActionResult> Put(long id, [FromBody] LibraryUpdateRequest request)
        {
            request.Id = id;
            var result = await _libraryService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(LibraryDelete, LibraryManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _libraryService.DeleteAsync(id);
            return NoContent();
        }

    }
}
