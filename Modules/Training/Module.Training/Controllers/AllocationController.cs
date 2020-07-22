using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;
using System;

namespace Module.Training.Controllers
{

    [Route("api/hostels/allocations")]
    [ApiController]
    public class AllocationController : ControllerBase
    {

        private readonly IAllocationService _allocationService;

        public AllocationController(
            IAllocationService allocationService)
        {
            _allocationService = allocationService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _allocationService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _allocationService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AllocationCreateRequest request)
        {
            var result = await _allocationService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] AllocationUpdateRequest request)
        {
            request.Id = id;
            var result = await _allocationService.UpdateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}/checkout")]
        public async Task<IActionResult> Checkout(long id, [FromBody] AllocationUpdateRequest request)
        {
            request.Id = id;
            var result = await _allocationService.CheckoutAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(long id)
        {
            var result = await _allocationService.CancelAsync(id);
            return result.ToCreatedResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _allocationService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/rent")]
        public async Task<ActionResult> GetRent(long id, DateTime checkout)
        {
            var result = await _allocationService.GetRent(id, checkout);
            return result.ToOkResult();
        }

        [HttpGet("batch-schedules")]
        public async Task<ActionResult> ListBatchSchedules([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _allocationService.ListBatchScheduleAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpPost("batch-schedule-checkout")]
        public async Task<IActionResult> BatchScheduleCheckout([FromBody] AllocationGroupCheckoutByBatchScheduleRequest request)
        {
            var result = await _allocationService.GroupCheckoutByBatchScheduleAsync(request);
            return result.ToCreatedResult();
        }

    }
}
