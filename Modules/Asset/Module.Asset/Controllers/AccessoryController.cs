using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Asset.Data;
using Module.Core.Shared;
using Module.Asset.Entities;

namespace Module.Asset.Controllers
{

    [Route("api/asset/accessories")]
    [ApiController]
    public class AccessoryController : ControllerBase
    {

        private readonly IAccessoryService _accessoryService;
        private readonly ICheckoutHistoryService _checkoutHistoryService;

        public AccessoryController(
            IAccessoryService service,
            ICheckoutHistoryService checkoutHistoryService)
        {
            _checkoutHistoryService = checkoutHistoryService;
            _accessoryService = service;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _accessoryService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _accessoryService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccessoryCreateRequest request)
        {
            var result = await _accessoryService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] AccessoryUpdateRequest request)
        {
            request.Id = id;
            var result = await _accessoryService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _accessoryService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/checkouts")]
        public async Task<ActionResult> ListCheckouts(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _accessoryService.ListCheckoutAsync(id, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}/histories")]
        public async Task<ActionResult> ListHistories(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _checkoutHistoryService.ListAsync(id, AssetType.Accessory, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpPost("{id}/checkouts")]
        public async Task<IActionResult> Checkout(long id, [FromBody] AccessoryCheckoutRequest request)
        {
            request.AccessoryId = id;
            var result = await _accessoryService.CheckoutAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPost("{id}/checkins")]
        public async Task<IActionResult> Checkin(long id, [FromBody] AccessoryCheckinRequest request)
        {
            request.Id = id;
            var result = await _accessoryService.CheckinAsync(request);
            return result.ToCreatedResult();
        }

    }
}
