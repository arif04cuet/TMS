using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Library.Data;
using System.Threading.Tasks;
using Module.Core.Shared;

using static Module.Core.Shared.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Library.Entities;

namespace Module.Library.Controllers
{
    [Route("api/libraries/cards")]
    [ApiController]
    public class LibraryCardController : ControllerBase
    {

        private readonly ILibraryCardService _libraryCardService;
        private readonly INameService<LibraryCardStatus> _libraryCardStatusService;
        private readonly INameService<LibraryCardType> _libraryCardTypeService;

        public LibraryCardController(
            ILibraryCardService libraryCardService,
            INameService<LibraryCardStatus> libraryCardStatusService,
            INameService<LibraryCardType> libraryCardTypeService)
        {
            _libraryCardService = libraryCardService;
            _libraryCardStatusService = libraryCardStatusService;
            _libraryCardTypeService = libraryCardTypeService;
        }

        [HttpGet]
        [RequirePermission(LibraryList, LibraryManage)]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryCardService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("assignable")]
        [RequirePermission(LibraryList, LibraryManage)]
        public async Task<ActionResult> ListAssigable([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryCardService.ListAssignableAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("types")]
        [RequirePermission(LibraryList, LibraryManage)]
        public async Task<ActionResult> ListCardTypes([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryCardTypeService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("status")]
        [RequirePermission(LibraryList, LibraryManage)]
        public async Task<ActionResult> ListCardStatues([FromQuery] PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _libraryCardStatusService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
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
