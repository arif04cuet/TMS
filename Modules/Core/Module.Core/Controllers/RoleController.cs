﻿using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using System.Threading.Tasks;
using Module.Core.Data;

using static Module.Core.Shared.PermissionConstants;
using Msi.UtilityKit.Pagination;
using Module.Core.Shared;

namespace Module.Core.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;

        public RoleController(
            IRoleService roleService,
            IPermissionService permissionService)
        {
            _roleService = roleService;
            _permissionService = permissionService;
        }

        [HttpGet]
        [RequirePermission(RoleList, RoleManage)]
        public async Task<ActionResult> List([FromQuery] PagingOptions pagingOptions)
        {
            var result = await _roleService.ListAsync(pagingOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _roleService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(RoleCreate, RoleManage)]
        public async Task<IActionResult> Post([FromBody] RoleUpdateRequest request)
        {
            var result = await _roleService.CreateRoleWithPermissionAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        [RequirePermission(RoleUpdate, RoleManage)]
        public async Task<IActionResult> Put(int id, [FromBody] RoleUpdateRequest request)
        {
            request.Id = id;
            var result = await _roleService.UpdateRoleAsync(request);
            return Ok(new Result(result));
        }

        [HttpGet("{id}/permissions")]
        [RequirePermission(RoleUpdate, RoleManage)]
        public async Task<IActionResult> ListRolePermission(long id, [FromQuery] PagingOptions pagingOptions)
        {
            var result = await _permissionService.ListRolePermissionsAsync(id, pagingOptions);
            return result.ToOkResult();
        }

        [HttpPut("{id}/permissions")]
        [RequirePermission(RoleUpdate, RoleManage)]
        public async Task<IActionResult> AssignPermissions(long id, [FromBody] RoleAssignPermissionRequest request)
        {
            request.Id = id;
            var result = await _permissionService.AssignRolePermission(id, request.Permissions);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(RoleDelete, RoleManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _roleService.DeleteAsync(id);
            return NoContent();
        }

    }
}
