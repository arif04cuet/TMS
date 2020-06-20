using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/batch-schedules/class-routines")]
    [ApiController]
    public class BatchScheduleClassRoutineController : ControllerBase
    {

        private readonly IClassRoutineService _classRoutineService;

        public BatchScheduleClassRoutineController(
            IClassRoutineService classRoutineService)
        {
            _classRoutineService = classRoutineService;
        }

        [HttpGet("/api/trainings/batch-schedules/{batchScheduleId}/class-routines")]
        public async Task<ActionResult> List(long batchScheduleId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _classRoutineService.ListAsync(batchScheduleId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _classRoutineService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClassRoutineCreateRequest request)
        {
            var result = await _classRoutineService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ClassRoutineUpdateRequest request)
        {
            request.Id = id;
            var result = await _classRoutineService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _classRoutineService.DeleteAsync(id);
            return NoContent();
        }


    }
}
