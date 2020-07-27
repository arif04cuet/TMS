using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.CMS.Data;

namespace Module.CMS.Controllers
{

    [Route("api/cms/contents")]
    [ApiController]
    public class ContentController : ControllerBase
    {

        private readonly IContentService _contentService;

        public ContentController(
            IContentService categoryService)
        {
            _contentService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions, [FromQuery] SearchOptions searchOptions)
        {
            var result = await _contentService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _contentService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContentCreateRequest request)
        {
            var result = await _contentService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] ContentUpdateRequest request)
        {
            request.Id = id;
            var result = await _contentService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _contentService.DeleteAsync(id);
            return NoContent();
        }

        [HttpDelete("{id?}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage(long imageId, long? id)
        {
            await _contentService.DeleteImageAsync(imageId, id);
            return NoContent();
        }

        [HttpDelete("{id?}/attachments/{attachmentId}")]
        public async Task<IActionResult> DeleteAttachment(long attachmentId, long? id)
        {
            await _contentService.DeleteAttachmentAsync(attachmentId, id);
            return NoContent();
        }

    }
}
