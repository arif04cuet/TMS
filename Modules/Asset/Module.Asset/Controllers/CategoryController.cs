using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Asset.Data;
using Module.Core.Shared;

namespace Module.Asset.Controllers
{

    [Route("api/asset/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery] long? parentId, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _service.ListAsync(parentId, pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("root")]
        public async Task<ActionResult> ListRoot([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _service.ListRootAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _service.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryCreateRequest request)
        {
            var result = await _service.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CategoryUpdateRequest request)
        {
            request.Id = id;
            var result = await _service.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
