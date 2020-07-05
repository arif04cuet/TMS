using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/batch-schedules/session-progress")]
    [ApiController]
    public class SessionProgress : ControllerBase
    {

        private readonly ISessionProgressService _sessionProgressService;

        public SessionProgress(
            ISessionProgressService sessionProgressService)
        {
            _sessionProgressService = sessionProgressService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]long batchScheduleId, [FromQuery]long? moduleId)
        {
            var result = await _sessionProgressService.ListAsync(batchScheduleId, moduleId);
            return result.ToOkResult();
        }

        [HttpPost("complete")]
        public async Task<IActionResult> CompleteMultiple([FromBody] SessionProgressCompleteRequest request)
        {
            var result = await _sessionProgressService.CompleteMultipleAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPost("/api/trainings/batch-schedules/{batchScheduleId}/session-progress/complete-and-generate-sheet")]
        public async Task<IActionResult> CompleteAndGenerateSheetMultiple(long batchScheduleId, [FromBody] SessionProgressCompleteRequest request)
        {
            request.BatchScheduleId = batchScheduleId;
            var result = await _sessionProgressService.CompleteMultipleAndGenerateSheetAsync(request);
            return File(result, "application/pdf", $"honorarium-sheet.pdf");
        }

        [HttpPost("{routinePeriodId}/complete")]
        public async Task<IActionResult> Complete(long routinePeriodId)
        {
            var result = await _sessionProgressService.CompleteAsync(routinePeriodId);
            return result.ToCreatedResult();
        }

        [HttpPost("/api/trainings/batch-schedules/{batchScheduleId}/session-progress/{routinePeriodId}/complete-and-generate-sheet")]
        public async Task<IActionResult> CompleteAndGenerateSheet(long batchScheduleId, long routinePeriodId)
        {
            var result = await _sessionProgressService.CompleteAndGenerateSheetAsync(batchScheduleId, routinePeriodId);
            return File(result, "application/pdf", $"honorarium-sheet.pdf");
        }

    }
}
