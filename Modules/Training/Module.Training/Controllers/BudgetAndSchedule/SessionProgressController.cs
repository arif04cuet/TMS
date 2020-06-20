using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
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

        [HttpGet("/api/trainings/batch-schedules/{batchScheduleId}/session-progress")]
        public async Task<ActionResult> List([FromRoute]long batchScheduleId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _sessionProgressService.ListAsync(batchScheduleId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _sessionProgressService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExamCreateRequest request)
        {
            var result = await _sessionProgressService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ExamUpdateRequest request)
        {
            request.Id = id;
            var result = await _sessionProgressService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _sessionProgressService.DeleteAsync(id);
            return NoContent();
        }


        [HttpGet("pdf-test")]
        public IActionResult PdfTest()
        {
            var pdf = _sessionProgressService.GenerateHonoriumSheetAsync();
            return File(pdf, "application/pdf", $"test.pdf");
        }

    }
}
