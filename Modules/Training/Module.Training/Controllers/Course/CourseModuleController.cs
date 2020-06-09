using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/courses/modules")]
    [ApiController]
    public class CourseModuleController : ControllerBase
    {

        private readonly ICourseModuleService _courseModuleService;

        public CourseModuleController(
            ICourseModuleService courseModuleService)
        {
            _courseModuleService = courseModuleService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _courseModuleService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _courseModuleService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseModuleCreateRequest request)
        {
            var result = await _courseModuleService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CourseModuleUpdateRequest request)
        {
            request.Id = id;
            var result = await _courseModuleService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _courseModuleService.DeleteAsync(id);
            return NoContent();
        }


    }
}
