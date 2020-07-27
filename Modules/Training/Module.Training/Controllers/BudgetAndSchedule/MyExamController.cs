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
        public async Task<IActionResult> Post([FromBody] SubmitExamAnswerRequest request)
        {
            var result = await _myExamService.SubmitAnswerAsync(request);
            return result.ToCreatedResult();
        }

    }
}
