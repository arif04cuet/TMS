using Microsoft.AspNetCore.Mvc;
using Module.Core.Data;
using Module.Core.Shared;
using System.Threading.Tasks;

namespace Module.Core.Controllers
{

    [ApiController]
    [Route("api/token")]
    public class TokenController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public TokenController(
            IUserService userService,
            ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TokenCreateRequest request)
        {
            var result = await _tokenService.CreateAsync(request);
            if (result != null)
            {
                return result.ToOkResult();
            }
            return Unauthorized();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody]TokenRefreshRequest request)
        {
            var result = await _tokenService.RefreshAsync(request);
            return result.ToOkResult();
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordRequest request)
        {
            var result = await _tokenService.CreateForgotPasswordToken(request);
            return result.ToOkResult();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordRequest request)
        {
            var result = await _tokenService.ResetPasswordAsync(request);
            return result.ToOkResult();
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke([FromBody]TokenRevokeRequest request)
        {
            var result = await _tokenService.RevokeAsync(request);
            return result.ToOkResult();
        }

    }
}
