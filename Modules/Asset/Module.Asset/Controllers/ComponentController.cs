using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Asset.Data;
using Module.Core.Shared;
using Module.Asset.Entities;

namespace Module.Asset.Controllers
{

    [Route("api/asset/components")]
    [ApiController]
    public class ComponentController : ControllerBase
    {

        private readonly IComponentService _componentService;
        private readonly ICheckoutHistoryService _checkoutHistoryService;

        public ComponentController(
            IComponentService componentService,
            ICheckoutHistoryService checkoutHistoryService)
        {
            _checkoutHistoryService = checkoutHistoryService;
            _componentService = componentService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _componentService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _componentService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComponentCreateRequest request)
        {
            var result = await _componentService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ComponentUpdateRequest request)
        {
            request.Id = id;
            var result = await _componentService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _componentService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/checkouts")]
        public async Task<ActionResult> ListCheckouts(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _componentService.ListCheckoutAsync(id, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}/checkouts/{checkoutId}")]
        public async Task<ActionResult> GetCheckout(long id, long checkoutId)
        {
            var result = await _componentService.GetCheckoutAsync(checkoutId);
            return result.ToOkResult();
        }

        [HttpGet("{id}/histories")]
        public async Task<ActionResult> ListHistories(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _checkoutHistoryService.ListAsync(id, AssetType.Component, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpPost("{id}/checkouts")]
        public async Task<IActionResult> Checkout(long id, [FromBody] ComponentCheckoutRequest request)
        {
            request.ComponentId = id;
            var result = await _componentService.CheckoutAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPost("{id}/checkins")]
        public async Task<IActionResult> Checkin(long id, [FromBody] ComponentCheckinRequest request)
        {
            request.Id = id;
            var result = await _componentService.CheckinAsync(request);
            return result.ToCreatedResult();
        }

    }
}
