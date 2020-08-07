using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.CMS.Data;

namespace Module.CMS.Controllers
{

    [Route("api/cms/faq")]
    [ApiController]
    public class FaqController : ControllerBase
    {

        private readonly IFaqService _FaqService;

        public FaqController(
            IFaqService categoryService)
        {
            _FaqService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery] SearchOptions searchOptions)
        {
            var result = await _FaqService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _FaqService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FaqCreateRequest request)
        {
            var result = await _FaqService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] FaqUpdateRequest request)
        {
            request.Id = id;
            var result = await _FaqService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _FaqService.DeleteAsync(id);
            return NoContent();
        }

    }
}
