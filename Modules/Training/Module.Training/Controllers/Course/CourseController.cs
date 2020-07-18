using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly ICourseService _courseService;

        public CourseController(
            ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _courseService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _courseService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseCreateRequest request)
        {
            var result = await _courseService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CourseUpdateRequest request)
        {
            request.Id = id;
            var result = await _courseService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _courseService.DeleteAsync(id);
            return NoContent();
        }

        [HttpDelete("{id?}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage(long imageId, long? id)
        {
            await _courseService.DeleteImageAsync(imageId, id);
            return NoContent();
        }


    }
}
