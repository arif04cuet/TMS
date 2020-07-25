using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/my-exams")]
    [ApiController]
    public class MyExamController : ControllerBase
    {

        private readonly IMyExamService _myExamService;

        public MyExamController(
            IMyExamService examService)
        {
            _myExamService = examService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _myExamService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _myExamService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExamCreateRequest request)
        {
            var result = await _myExamService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ExamUpdateRequest request)
        {
            request.Id = id;
            var result = await _myExamService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _myExamService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("/api/trainings/batch-schedules/{batchScheduleId}/my-exams/{examId}/result")]
        public async Task<ActionResult> GetResult(long batchScheduleId, long examId)
        {
            var result = await _myExamService.ListParticipantAsync(batchScheduleId, examId);
            return result.ToOkResult();
        }

        [HttpPut("{examId}/result")]
        public async Task<ActionResult> UpdateResult([FromBody] ExamMarkUpdateRequest request, long examId)
        {
            request.Exam = examId;
            var result = await _myExamService.UpdateMarksAsync(request);
            return result.ToOkResult();
        }


    }
}
