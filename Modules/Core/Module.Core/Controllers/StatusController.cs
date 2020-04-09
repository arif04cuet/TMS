using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Core.ViewModels;
using System.Threading.Tasks;
using Module.Core.Data;

using static Module.Core.Data.PermissionConstants;
using Msi.UtilityKit.Pagination;

namespace Module.Core.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly IStatusService _statusService;

        public StatusController(
            IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        [RequirePermission(RoleList)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions)
        {
            var result = await _statusService.ListAsync(pagingOptions);
            return Ok(new Response(result));
        }

        [HttpGet("{id}")]
        [RequirePermission(RoleView)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _statusService.Get(id);
            return Ok(new Response(result));
        }

    }
}
