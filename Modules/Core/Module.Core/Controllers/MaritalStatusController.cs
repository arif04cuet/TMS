using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Core.ViewModels;
using System.Threading.Tasks;
using Module.Core.Data;

using static Module.Core.Data.PermissionConstants;
using Msi.UtilityKit.Pagination;

namespace Module.Core.Controllers
{
    [Route("api/marital-status")]
    [ApiController]
    public class MaritalStatusController : ControllerBase
    {

        private readonly IMatiralStatusService _matiralStatusService;

        public MaritalStatusController(
            IMatiralStatusService matiralStatusService)
        {
            _matiralStatusService = matiralStatusService;
        }

        [HttpGet]
        [RequirePermission(RoleList)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions)
        {
            var result = await _matiralStatusService.ListAsync(pagingOptions);
            return Ok(new Response(result));
        }

        [HttpGet("{id}")]
        [RequirePermission(RoleView)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _matiralStatusService.Get(id);
            return Ok(new Response(result));
        }

    }
}
