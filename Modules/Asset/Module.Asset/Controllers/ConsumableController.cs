using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Asset.Data;
using Module.Core.Shared;
using Module.Asset.Entities;

namespace Module.Asset.Controllers
{

    [Route("api/asset/consumables")]
    [ApiController]
    public class ConsumableController : ControllerBase
    {

        private readonly IConsumableService _consumableService;
        private readonly ICheckoutHistoryService _checkoutHistoryService;

        public ConsumableController(
            IConsumableService consumableService,
            ICheckoutHistoryService checkoutHistoryService)
        {
            _checkoutHistoryService = checkoutHistoryService;
            _consumableService = consumableService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _consumableService.ListAsync(null, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("group")]
        public async Task<ActionResult> ListGroupByItemCode([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _consumableService.ListGroupByItemCodeAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{itemCodeId}/items")]
        public async Task<ActionResult> ListItemsByItemCode(long itemCodeId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _consumableService.ListAsync(itemCodeId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _consumableService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConsumableCreateRequest request)
        {
            var result = await _consumableService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ConsumableUpdateRequest request)
        {
            request.Id = id;
            var result = await _consumableService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _consumableService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/checkouts")]
        public async Task<ActionResult> ListCheckouts(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _consumableService.ListCheckoutAsync(id, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("checkouts")]
        public async Task<ActionResult> ListCheckoutsByItemCode([FromQuery] long itemCodeId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _consumableService.ListCheckoutByItemCodeAsync(itemCodeId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}/histories")]
        public async Task<ActionResult> ListHistories(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _checkoutHistoryService.ListAsync(id, AssetType.Consumable, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("histories")]
        public async Task<ActionResult> ListHistoriesByItemCode(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _checkoutHistoryService.ListAsync(id, AssetType.Consumable, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpPost("{id}/checkouts")]
        public async Task<IActionResult> Checkout(long id, [FromBody] ConsumableCheckoutRequest request)
        {
            request.ConsumableId = id;
            var result = await _consumableService.CheckoutAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPost("checkouts")]
        public async Task<IActionResult> CheckoutByItemCode([FromBody] ConsumableCheckoutByItemCodeRequest request)
        {
            var result = await _consumableService.CheckoutByItemCodeAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPost("{id}/checkins")]
        public async Task<IActionResult> Checkin(long id, [FromBody] ConsumableCheckinRequest request)
        {
            request.Id = id;
            var result = await _consumableService.CheckinAsync(request);
            return result.ToCreatedResult();
        }

    }
}
