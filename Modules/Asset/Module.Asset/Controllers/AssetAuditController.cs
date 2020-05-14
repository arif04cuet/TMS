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
    public class AssetAuditController : ControllerBase
    {

        private readonly IAssetAuditService _assetAuditService;

        public AssetAuditController(
            IAssetAuditService assetAuditService)
        {
            _assetAuditService = assetAuditService;
        }

        [HttpGet("{id}/audit")]
        public async Task<ActionResult> List(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _assetAuditService.ListAsync(id, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("audit")]
        public async Task<ActionResult> ListAll([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _assetAuditService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("audit/{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _assetAuditService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost("audit")]
        public async Task<IActionResult> Post([FromBody] AssetAuditCreateRequest request)
        {
            var result = await _assetAuditService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("audit/{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] AssetAuditUpdateRequest request)
        {
            request.Id = id;
            var result = await _assetAuditService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("audit/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _assetAuditService.DeleteAsync(id);
            return NoContent();
        }

    }
}
