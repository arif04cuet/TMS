using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _allocationService.DeleteAsync(id);
            return NoContent();
        }


    }
}
