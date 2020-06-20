using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/batch-schedules")]
    [ApiController]
    public class BatchScheduleController : ControllerBase
    {

        private readonly IBatchScheduleService _batchScheduleService;

        public BatchScheduleController(
            IBatchScheduleService batchScheduleService)
        {
            _batchScheduleService = batchScheduleService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery] string scheduleStatus, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _batchScheduleService.ListAsync(scheduleStatus, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _batchScheduleService.Get(id);
            return result.ToOkResult();
        }

        [HttpGet("{id}/modules")]
        public async Task<ActionResult> ListModules(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _batchScheduleService.ListModuleAsync(id, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}/participants")]
        public async Task<ActionResult> ListParticipant(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _batchScheduleService.ParticipantListAsync(id, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BatchScheduleCreateRequest request)
        {
            var result = await _batchScheduleService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] BatchScheduleUpdateRequest request)
        {
            request.Id = id;
            var result = await _batchScheduleService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _batchScheduleService.DeleteAsync(id);
            return NoContent();
        }


    }
}
