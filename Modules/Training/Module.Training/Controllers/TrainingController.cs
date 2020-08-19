using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/training")]
    [ApiController]
    public class TrainingController : ControllerBase
    {

        private readonly ITrainingService _trainingService;

        public TrainingController(
            ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult> Dashboard()
        {
            var result = await _trainingService.GetDashboard();
            return result.ToOkResult();
        }

    }
}
