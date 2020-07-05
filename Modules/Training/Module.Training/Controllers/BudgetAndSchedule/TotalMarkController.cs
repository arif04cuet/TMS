using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/batch-schedules/{id}/total-marks")]
    [ApiController]
    public class TotalMarkController : ControllerBase
    {

        private readonly ITotalMarkService _totalMarkService;

        public TotalMarkController(
            ITotalMarkService totalMarkService)
        {
            _totalMarkService = totalMarkService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromRoute]long id)
        {
            var result = await _totalMarkService.ListAsync(id);
            return result.ToOkResult();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromRoute]long id, [FromBody]TotalMarkUpdateRequest request)
        {
            request.BatchSchedule = id;
            var result = await _totalMarkService.UpdateAsync(request);
            return result.ToOkResult();
        }

    }
}
