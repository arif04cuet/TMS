using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/honorarium-heads")]
    [ApiController]
    public class HonorariumController : ControllerBase
    {

        private readonly IHonorariumService _honorariumService;

        public HonorariumController(
            IHonorariumService honorariumService)
        {
            _honorariumService = honorariumService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _honorariumService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("/api/trainings/latest-year-honorarium-heads")]
        public async Task<ActionResult> ListLatestYearHonorariumHeads([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _honorariumService.ListLatestYearHonorariumHeadsAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _honorariumService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HonorariumCreateRequest request)
        {
            var result = await _honorariumService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] HonorariumUpdateRequest request)
        {
            request.Id = id;
            var result = await _honorariumService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _honorariumService.DeleteAsync(id);
            return NoContent();
        }


    }
}
