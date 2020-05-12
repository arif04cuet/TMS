using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Asset.Data;
using Module.Core.Shared;

namespace Module.Asset.Controllers
{

    [Route("api/asset")]
    [ApiController]
    public class AccessoryMaintenanceController : ControllerBase
    {

        private readonly IAssetMaintenanceService _accessoryMaintenanceService;

        public AccessoryMaintenanceController(
            IAssetMaintenanceService accessoryMaintenanceService)
        {
            _accessoryMaintenanceService = accessoryMaintenanceService;
        }

        [HttpGet("{id}/maintenances")]
        public async Task<ActionResult> List(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _accessoryMaintenanceService.ListAsync(id, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("maintenances")]
        public async Task<ActionResult> ListAll([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _accessoryMaintenanceService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("maintenances/{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _accessoryMaintenanceService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost("maintenances")]
        public async Task<IActionResult> Post([FromBody] AssetMaintenanceCreateRequest request)
        {
            var result = await _accessoryMaintenanceService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("maintenances/{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] AssetMaintenanceUpdateRequest request)
        {
            request.Id = id;
            var result = await _accessoryMaintenanceService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("maintenances/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _accessoryMaintenanceService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("maintenances/types")]
        public ActionResult GetTypes([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = _accessoryMaintenanceService.ListTypes(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

    }
}
