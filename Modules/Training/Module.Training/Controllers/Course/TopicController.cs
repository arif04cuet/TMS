using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;

namespace Module.Training.Controllers
{

    [Route("api/courses/topics")]
    [ApiController]
    public class TopicController : ControllerBase
    {

        private readonly ITopicService _topicService;

        public TopicController(
            ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _topicService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _topicService.Get(id);
            return result.ToOkResult();
        }

        [HttpGet("{id}/methods")]
        public async Task<ActionResult> ListMethods(long id)
        {
            var result = await _topicService.ListMethodAsync(id);
            return result.ToOkResult();
        }

        [HttpGet("{id}/resource-persons")]
        public async Task<ActionResult> ListResourcePersons(long id)
        {
            var result = await _topicService.ListResourcePersonAsync(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TopicCreateRequest request)
        {
            var result = await _topicService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] TopicUpdateRequest request)
        {
            request.Id = id;
            var result = await _topicService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _topicService.DeleteAsync(id);
            return NoContent();
        }


    }
}
