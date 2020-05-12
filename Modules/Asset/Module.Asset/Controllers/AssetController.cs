using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Asset.Data;
using Module.Core.Shared;
using Module.Asset.Entities;

namespace Module.Asset.Controllers
{

    [Route("api/asset")]
    [ApiController]
    public class AssetController : ControllerBase
    {

        private readonly IAssetService _assetService;
        private readonly ICheckoutHistoryService _checkoutHistoryService;

        public AssetController(
            IAssetService assetService,
            ICheckoutHistoryService checkoutHistoryService)
        {
            _checkoutHistoryService = checkoutHistoryService;
            _assetService = assetService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _assetService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _assetService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AssetCreateRequest request)
        {
            var result = await _assetService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] AssetUpdateRequest request)
        {
            request.Id = id;
            var result = await _assetService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _assetService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/histories")]
        public async Task<ActionResult> ListHistories(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _checkoutHistoryService.ListAsync(id, AssetType.Asset, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpPost("{id}/checkouts")]
        public async Task<IActionResult> Checkout(long id, [FromBody] AssetCheckoutRequest request)
        {
            request.AssetId = id;
            var result = await _assetService.CheckoutAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPost("{id}/checkins")]
        public async Task<IActionResult> Checkin(long id, [FromBody] AssetCheckinRequest request)
        {
            request.Id = id;
            //request.AssetId = assetId;
            var result = await _assetService.CheckinAsync(request);
            return result.ToCreatedResult();
        }

        [HttpGet("{id}/components")]
        public async Task<ActionResult> ListComponents(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _assetService.ListComponentsAsync(id, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

    }
}
