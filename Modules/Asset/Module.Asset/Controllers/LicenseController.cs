using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Asset.Data;
using Module.Core.Shared;
using Module.Asset.Entities;

namespace Module.Asset.Controllers
{

    [Route("api/asset/licenses")]
    [ApiController]
    public class LicenseController : ControllerBase
    {

        private readonly ILicenseService _service;
        private readonly ICheckoutHistoryService _checkoutHistoryService;

        public LicenseController(ILicenseService service, ICheckoutHistoryService checkoutHistoryService)
        {
            _service = service;
            _checkoutHistoryService = checkoutHistoryService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _service.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _service.Get(id);
            return result.ToOkResult();
        }


        [HttpGet("{id}/details")]
        public async Task<ActionResult> GetDetails(long id)
        {
            var result = await _service.GetDetails(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LicenseCreateRequest request)
        {
            var result = await _service.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] LicenseUpdateRequest request)
        {
            request.Id = id;
            var result = await _service.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpPost("{id}/checkouts")]
        public async Task<IActionResult> Checkout(long id, [FromBody] LicenseCheckoutRequest request)
        {
            request.Id = id;
            var result = await _service.CheckoutAsync(request);
            return result.ToOkResult();
        }

        [HttpPost("{id}/checkins")]
        public async Task<IActionResult> Checkin(long id, [FromBody] LicenseCheckinRequest request)
        {
            request.Id = id;
            var result = await _service.CheckinAsync(request);
            return result.ToCreatedResult();
        }

        [HttpGet("{id}/histories")]
        public async Task<ActionResult> ListHistories(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _checkoutHistoryService.ListAsync(id, AssetType.License, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
