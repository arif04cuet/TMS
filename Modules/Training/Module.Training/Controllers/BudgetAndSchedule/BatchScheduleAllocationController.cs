using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/batch-schedules/allocations")]
    [ApiController]
    public class BatchScheduleAllocationController : ControllerBase
    {

        private readonly IBatchScheduleAllocationService _batchScheduleAllocationService;

        public BatchScheduleAllocationController(
            IBatchScheduleAllocationService batchScheduleAllocationService)
        {
            _batchScheduleAllocationService = batchScheduleAllocationService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _batchScheduleAllocationService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpPost("export")]
        public async Task<ActionResult> ExportList([FromQuery]SearchOptions searchOptions)
        {
            var result = await _batchScheduleAllocationService.ExportAllocationAsync(searchOptions);
            if (result != null && result.Length > 0)
            {
                string contetntType = @"text/csv";
                HttpContext.Response.ContentType = contetntType;
                var fileResult = new FileContentResult(result, contetntType);
                fileResult.FileDownloadName = $"batch-schedule-allocation.csv";
                return fileResult;
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _batchScheduleAllocationService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BatchScheduleAllocationCreateRequest request)
        {
            var result = await _batchScheduleAllocationService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] BatchScheduleAllocationUpdateRequest request)
        {
            request.Id = id;
            var result = await _batchScheduleAllocationService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] BatchScheduleAllocationUpdateStatusRequest request)
        {
            var result = await _batchScheduleAllocationService.UpdateStatusAsync(request);
            return result.ToOkResult();
        }

        [HttpPut("migrate")]
        public async Task<IActionResult> MigrateToNextBatch([FromBody] MigrateToNextBatchRequest request)
        {
            var result = await _batchScheduleAllocationService.MigrateToNextBatchAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _batchScheduleAllocationService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/certificate")]
        public async Task<IActionResult> DownloadCertificate(long id)
        {
            var result = await _batchScheduleAllocationService.DownloadCertificateAsync(id);
            return File(result, "application/pdf", $"certificate.pdf");
        }

    }
}
