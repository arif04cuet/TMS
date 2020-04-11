using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Core.ViewModels;
using System.Threading.Tasks;
using Module.Core.Data;

using static Module.Core.Data.PermissionConstants;
using Msi.UtilityKit.Pagination;

namespace Module.Core.Controllers
{
    [Route("api/blood-groups")]
    [ApiController]
    public class BloodGroupController : ControllerBase
    {

        private readonly IBloodGroupService _bloodGroupService;

        public BloodGroupController(
            IBloodGroupService bloodGroupService)
        {
            _bloodGroupService = bloodGroupService;
        }

        [HttpGet]
        [RequirePermission(RoleList)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions)
        {
            var result = await _bloodGroupService.ListAsync(pagingOptions);
            return Ok(new Response(result));
        }

        [HttpGet("{id}")]
        [RequirePermission(RoleView)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _bloodGroupService.Get(id);
            return Ok(new Response(result));
        }

    }
}
