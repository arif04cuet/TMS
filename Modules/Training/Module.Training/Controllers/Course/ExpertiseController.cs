using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/courses/expertise")]
    [ApiController]
    public class ExpertiseController : ControllerBase
    {

        private readonly IExpertiseService _expertiseService;

        public ExpertiseController(
            IExpertiseService expertiseService)
        {
            _expertiseService = expertiseService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _expertiseService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _expertiseService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpertiseCreateRequest request)
        {
            var result = await _expertiseService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ExpertiseUpdateRequest request)
        {
            request.Id = id;
            var result = await _expertiseService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _expertiseService.DeleteAsync(id);
            return NoContent();
        }


    }
}
