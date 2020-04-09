using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using Module.Core.ViewModels;
using System.Threading.Tasks;

using static Module.Core.Data.PermissionConstants;
using Module.Core.Data;
using Msi.UtilityKit.Pagination;

namespace Module.Core.Controllers
{
    //[ApiVersion("v1")]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [RequirePermission(UserList)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions)
        {
            var result = await _userService.ListAsync(pagingOptions);
            return Ok(new Response(result));
        }

        [HttpGet("{id}")]
        [RequirePermission(UserView)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _userService.Get(id);
            return Ok(new Response(result));
        }

        [HttpPost]
        [RequirePermission(UserCreate)]
        public async Task<IActionResult> Post([FromBody] UserCreateRequest request)
        {
            var result = await _userService.CreateAsync(request);
            return Created("", new Response(result));
        }

        [HttpPut("{id}")]
        [RequirePermission(UserUpdate)]
        public async Task<IActionResult> Put(long id, [FromBody] UserUpdateRequest request)
        {
            request.Id = id;
            var result = await _userService.UpdateAsync(request);
            return Ok(new Response(result));
        }

        [HttpDelete("{id}")]
        [RequirePermission(UserDelete)]
        public async Task<IActionResult> Delete(long id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

    }
}
