using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/course-schedules")]
    [ApiController]
    public class CourseScheduleController : ControllerBase
    {

        private readonly ICourseScheduleService _courseScheduleService;

        public CourseScheduleController(
            ICourseScheduleService courseScheduleService)
        {
            _courseScheduleService = courseScheduleService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _courseScheduleService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _courseScheduleService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CourseScheduleCreateRequest request)
        {
            var result = await _courseScheduleService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CourseScheduleUpdateRequest request)
        {
            request.Id = id;
            var result = await _courseScheduleService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _courseScheduleService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("budgets")]
        public async Task<ActionResult> BudgetList([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _courseScheduleService.BudgetListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

    }
}
