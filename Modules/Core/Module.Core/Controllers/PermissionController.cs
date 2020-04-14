using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using System.Threading.Tasks;
using Module.Core.Data;

using static Module.Core.Shared.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Module.Core.Shared;

namespace Module.Core.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    public class PermissionController : ControllerBase
    {

        private readonly IPermissionService _permissionService;

        public PermissionController(
            IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        [RequirePermission(RoleList)]
        public async Task<ActionResult> List(long? userId, [FromQuery]PagingOptions pagingOptions)
        {
            var result = await _permissionService.ListAllPermissionsAsync(userId, pagingOptions);
            return result.ToOkResult();
        }

    }
}
