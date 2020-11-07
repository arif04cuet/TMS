using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/courses/resource-persons")]
    [ApiController]
    public class ResourcePersonController : ControllerBase
    {

        private readonly IResourcePersonService _resourcePersonService;

        public ResourcePersonController(
            IResourcePersonService resourcePersonService)
        {
            _resourcePersonService = resourcePersonService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _resourcePersonService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _resourcePersonService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ResourcePersonCreateRequest request)
        {
            var result = await _resourcePersonService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ResourcePersonUpdateRequest request)
        {
            request.Id = id;
            var result = await _resourcePersonService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _resourcePersonService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("assignable-users")]
        public async Task<ActionResult> ListAssignableUsers([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _resourcePersonService.ListAssignableUsersAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }


    }
}
