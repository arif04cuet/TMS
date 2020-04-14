using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System;
using System.IO;
using Module.Core.Data.Services;

namespace Module.Core.Controllers
{

    [Route("api/common")]
    [ApiController]
    public class CommonController : ControllerBase
    {

        private readonly IMediaService _mediaService;

        public CommonController(
            IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, bool isPublic)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);

            return Ok(_mediaService.GetMediaUrl(fileName));
        }

    }
}
