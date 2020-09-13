using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Asset.Data;
using Module.Core.Shared;

namespace Module.Asset.Controllers
{

    [Route("api/asset/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly IAssetReportService _assetReportService;

        public ReportController(
            IAssetReportService assetReportService)
        {
            _assetReportService = assetReportService;
        }

        [HttpGet("activity-log")]
        public async Task<ActionResult> ActivityLog([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _assetReportService.ActivityLogAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("depreciation")]
        public async Task<ActionResult> DepreciationReport([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _assetReportService.DepreciationReportAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("depreciation/{assetId}/schedules")]
        public async Task<ActionResult> DepreciationSchedulesReport(long assetId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _assetReportService.DepreciationScheduleReportAsync(assetId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("license")]
        public async Task<ActionResult> LicenseReport([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _assetReportService.LicenseReportAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("maintenance")]
        public async Task<ActionResult> MaintenanceReport([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _assetReportService.MaintenanceReportAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

    }
}
