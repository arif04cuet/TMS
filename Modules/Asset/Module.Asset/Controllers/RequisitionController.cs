using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Asset.Data;
using Module.Core.Shared;

namespace Module.Asset.Controllers
{

    [Route("api/requisitions")]
    [ApiController]
    public class RequisitionController : ControllerBase
    {

        private readonly IRequisitionService _requisitionService;
        public RequisitionController(
            IRequisitionService requisitionService)
        {
            _requisitionService = requisitionService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _requisitionService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _requisitionService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequisitionCreateRequest request)
        {
            var result = await _requisitionService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] RequisitionUpdateRequest request)
        {
            request.Id = id;
            var result = await _requisitionService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _requisitionService.DeleteAsync(id);
            return NoContent();
        }

    }
}
