using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.CMS.Data;

namespace Module.CMS.Controllers
{

    [Route("api/cms/banners")]
    [ApiController]
    public class BannerController : ControllerBase
    {

        private readonly IBannerService _bannerService;

        public BannerController(
            IBannerService categoryService)
        {
            _bannerService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery] SearchOptions searchOptions)
        {
            var result = await _bannerService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _bannerService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BannerCreateRequest request)
        {
            var result = await _bannerService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] BannerUpdateRequest request)
        {
            request.Id = id;
            var result = await _bannerService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _bannerService.DeleteAsync(id);
            return NoContent();
        }

    }
}
