using Microsoft.AspNetCore.Mvc;
using Module.Core.Attributes;
using System.Threading.Tasks;

using static Module.Core.Shared.PermissionConstants;
using Module.Core.Data;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using Module.Core.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Module.Core.Controllers
{
    //[ApiVersion("v1")]
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly IPermissionService _permissionService;

        public UserController(
            IUserService userService,
            IProfileService profileService,
            IPermissionService permissionService)
        {
            _userService = userService;
            _profileService = profileService;
            _permissionService = permissionService;
        }

        [HttpGet]
        [RequirePermission(UserList, UserManage)]
        public async Task<ActionResult> List([FromQuery]PagingOptions pagingOptions, [FromQuery]SearchOptions searchOptions)
        {
            var result = await _userService.ListAsync(pagingOptions, searchOptions);
            return result.ToOkResult();
        }

        [HttpGet("{id}")]
        [RequirePermission(UserView, UserManage)]
        public async Task<ActionResult> Get(long id)
        {
            var result = await _userService.Get(id);
            return result.ToOkResult();
        }

        [HttpPost]
        [RequirePermission(UserCreate, UserManage)]
        public async Task<IActionResult> Post([FromBody] UserCreateRequest request)
        {
            var result = await _userService.CreateAsync(request);
            return result.ToCreatedResult();
        }

        [HttpPut("{id}")]
        [RequirePermission(UserUpdate, UserManage)]
        public async Task<IActionResult> Put(long id, [FromBody] UserUpdateRequest request)
        {
            request.Id = id;
            var result = await _userService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpDelete("{id}")]
        [RequirePermission(UserDelete, UserManage)]
        public async Task<IActionResult> Delete(long id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/profile")]
        [RequirePermission(ProfileView, ProfileManage, UserManage)]
        public async Task<ActionResult> GetProfile(long id)
        {
            var result = await _profileService.Get(id);
            return result.ToOkResult();
        }

        [HttpPut("{id}/profile")]
        [RequirePermission(UserUpdate, UserManage)]
        public async Task<IActionResult> Put(long id, [FromBody] ProfileRequest request)
        {
            request.UserId = id;
            var result = await _profileService.UpdateAsync(request);
            return result.ToOkResult();
        }

        [HttpGet("{id}/permissions")]
        [RequirePermission(RoleUpdate, RoleManage)]
        public async Task<IActionResult> ListRolePermission(long id, [FromQuery]PagingOptions pagingOptions)
        {
            var result = await _permissionService.ListUserPermissionsAsync(id, pagingOptions);
            return result.ToOkResult();
        }

        [HttpPut("{id}/permissions")]
        [RequirePermission(RoleUpdate, RoleManage)]
        public async Task<IActionResult> AssignPermissions(long id, [FromBody] RoleAssignPermissionRequest request)
        {
            request.Id = id;
            var result = await _permissionService.AssignUserPermission(id, request.Permissions);
            return result.ToOkResult();
        }

        [AllowAnonymous]
        [HttpPost("registration-from-frontend")]
        public async Task<IActionResult> RegistrationFromFrontend([FromBody] UserCreateFromFrontendRequest request)
        {
            var result = await _userService.CreateFromFrontendAsync(request);
            return result.ToCreatedResult();
        }

    }
}
