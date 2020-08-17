using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using System.Threading.Tasks;
using Module.Core.Shared;

using static Module.Core.Shared.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Library.Data;

namespace Module.Library.Controllers
{
    [Route("api/libraries/racks")]
    [ApiController]
    public class RackController : ControllerBase
    {

        private readonly IRackService _rackService;

        public RackController(
            IRackService rackService)
        {
            _rackService = rackService;
        }

        [HttpGet]
        [RequirePermission(RackList, RackManage)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _rackService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("/api/libraries/{libraryId}/racks")]
        [RequirePermission(RackList, RackManage)]
        public async Task<ActionResult> ListLibraryRacks(long libraryId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _rackService.ListLibraryRacksAsync(libraryId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _rackService.GetAsync(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(RackCreate, RackManage)]
        public async Task<IActionResult> Post([FromBody] RackCreateRequest request)
        {
            var result = await _rackService.CreateAsync(request);
            return result.ToCreatedResult($"api/libraries/racks/{request}");
        }

        [HttpPut("{id}")]
        [RequirePermission(RackUpdate, RackManage)]
        public async Task<IActionResult> Put(int id, [FromBody] RackUpdateRequest request)
        {
            request.Id = id;
            var result = await _rackService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(RackDelete, RackManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _rackService.DeleteAsync(id);
            return NoContent();
        }

    }
}
