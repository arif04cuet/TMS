using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using System.Threading.Tasks;

using static Module.Core.Shared.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Module.Core.Shared;
using Msi.UtilityKit.Search;
using Module.Core.Data;

namespace Module.Core.Controllers
{
    [Route("api/offices")]
    [ApiController]
    public class OfficeController : ControllerBase
    {

        private readonly IOfficeService _officeService;

        public OfficeController(
            IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet]
        [RequirePermission(OfficeList, OfficeManage)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _officeService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _officeService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(OfficeCreate, OfficeManage)]
        public async Task<IActionResult> Post([FromBody] OfficeCreateRequest request)
        {
            var result = await _officeService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        [RequirePermission(OfficeUpdate, OfficeManage)]
        public async Task<IActionResult> Put(int id, [FromBody] OfficeUpdateRequest request)
        {
            request.Id = id;
            var result = await _officeService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(OfficeDelete, OfficeManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _officeService.DeleteAsync(id);
            return NoContent();
        }

    }
}
