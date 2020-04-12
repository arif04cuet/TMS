using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Core.ViewModels;
using System.Threading.Tasks;

using static Module.Core.Data.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Asset.Data;

namespace Module.Asset.Controllers
{
    //[ApiVersion("v1")]
    [Route("api/vendors")]
    [ApiController]
    public class VendorController : ControllerBase
    {

        private readonly IVendorService _service;

        public VendorController(IVendorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _service.ListAsync(pagingOptions, searchOptions);
            return Ok(new Response(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _service.Get(id);
            return Ok(new Response(result));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VendorCreateRequest request)
        {
            var result = await _service.CreateAsync(request);
            return Created("", new Response(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] VendorUpdateRequest request)
        {
            request.Id = id;
            var result = await _service.UpdateAsync(request);
            return Ok(new Response(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
