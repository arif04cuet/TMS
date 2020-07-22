using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Module.Training.Data;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System;
using System.IO;
using Module.Core.Data;

namespace Module.Training.Controllers
{

    [Route("api/trainings/batch-schedules/{id}/galleries")]
    [ApiController]
    public class BatchScheduleGalleryController : ControllerBase
    {

        private readonly IBatchScheduleGalleryService _batchScheduleGalleryService;
        private readonly IMediaService _mediaService;

        public BatchScheduleGalleryController(
            IBatchScheduleGalleryService batchScheduleGalleryService,
            IMediaService mediaService)
        {
            _mediaService = mediaService;
            _batchScheduleGalleryService = batchScheduleGalleryService;
        }


        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromRoute] long id)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            var mediaId = await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);

            var galleryItemRequest = new BatchScheduleGalleryItemCreateRequest
            {
                BatchScheduleId = id,
                MediaId = mediaId
            };
            var result = await _batchScheduleGalleryService.CreateAsync(galleryItemRequest);

            return result.ToOkResult();
        }

        [HttpGet("{galleryItemId}")]
        public async Task<ActionResult> Get(long id, long galleryItemId)
        {
            var result = await _batchScheduleGalleryService.Get(id, galleryItemId);
            return result.ToOkResult();
        }

        [HttpDelete("{galleryItemId}")]
        public async Task<IActionResult> Delete(long id, long galleryItemId)
        {
            await _batchScheduleGalleryService.DeleteAsync(id, galleryItemId);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> List(long id, [FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _batchScheduleGalleryService.ListAsync(id, pagingOptions, searchOptions);
            return result.ToOkResult();
        }


    }
}
