using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Core.ViewModels;
using System.Threading.Tasks;
using Module.Core.Data;

using static Module.Core.Data.PermissionConstants;
using Msi.UtilityKit.Pagination;

namespace Module.Core.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;

        public RoleController(
            IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [RequirePermission(RoleList)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions)
        {
            var result = await _roleService.ListAsync(pagingOptions);
            return Ok(new Response(result));
        }

        [HttpGet("{id}")]
        [RequirePermission(RoleView)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _roleService.Get(id);
            return Ok(new Response(result));
        }

        [HttpPost]
        [RequirePermission(RoleCreate)]
        public async Task<IActionResult> Post([FromBody] RoleCreateRequest request)
        {
            var result = await _roleService.CreateAsync(request);
            return Created("", new Response(result));
        }

        [HttpPut("{id}")]
        [RequirePermission(RoleUpdate)]
        public async Task<IActionResult> Put(int id, [FromBody] RoleUpdateRequest request)
        {
            request.Id = id;
            var result = await _roleService.UpdateAsync(request);
            return Ok(new Response(result));
        }

        [HttpDelete("{id}")]
        [RequirePermission(RoleDelete)]
        public async Task<IActionResult> Delete(long id)
        {
            await _roleService.DeleteAsync(id);
            return NoContent();
        }

    }
}
