using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/course-schedules/budgets")]
    [ApiController]
    public class BudgetController : ControllerBase
    {

        private readonly IBudgetService _budgetService;

        public BudgetController(
            IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet("api/trainings/course-schedules/{courseScheduleId}/budgets")]
        public async Task<ActionResult> List(long courseScheduleId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _budgetService.ListAsync(courseScheduleId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _budgetService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BudgetCreateRequest request)
        {
            var result = await _budgetService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] BudgetUpdateRequest request)
        {
            request.Id = id;
            var result = await _budgetService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _budgetService.DeleteAsync(id);
            return NoContent();
        }


    }
}
