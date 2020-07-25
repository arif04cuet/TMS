using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/batch-schedules/exams")]
    [ApiController]
    public class ExamController : ControllerBase
    {

        private readonly IExamService _examService;

        public ExamController(
            IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet("/api/trainings/batch-schedules/{batchScheduleId}/exams")]
        public async Task<ActionResult> List([FromRoute]long batchScheduleId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _examService.ListAsync(batchScheduleId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _examService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExamCreateRequest request)
        {
            var result = await _examService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ExamUpdateRequest request)
        {
            request.Id = id;
            var result = await _examService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _examService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("/api/trainings/batch-schedules/{batchScheduleId}/exams/{examId}/result")]
        public async Task<ActionResult> GetResult(long batchScheduleId, long examId)
        {
            var result = await _examService.ListParticipantAsync(batchScheduleId, examId);
            return result.ToOkResult();
        }

        [HttpPut("{examId}/result")]
        public async Task<ActionResult> UpdateResult([FromBody] ExamMarkUpdateRequest request, long examId)
        {
            request.Exam = examId;
            var result = await _examService.UpdateMarksAsync(request);
            return result.ToOkResult();
        }

        [HttpPost("{examId}/download")]
        public async Task<IActionResult> DownloadExamPaper(long examId)
        {
            var result = await _examService.DownloadExamPaperAsync(examId);
            return File(result, "application/pdf", $"exam-paper.pdf");
        }


    }
}
