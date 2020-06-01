using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/courses/evaluation-methods")]
    [ApiController]
    public class EvaluationMethodController : ControllerBase
    {

        private readonly IEvaluationMethodService _evaluationMethodService;

        public EvaluationMethodController(
            IEvaluationMethodService evaluationMethodService)
        {
            _evaluationMethodService = evaluationMethodService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _evaluationMethodService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _evaluationMethodService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EvaluationMethodCreateRequest request)
        {
            var result = await _evaluationMethodService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] EvaluationMethodUpdateRequest request)
        {
            request.Id = id;
            var result = await _evaluationMethodService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _evaluationMethodService.DeleteAsync(id);
            return NoContent();
        }


    }
}
