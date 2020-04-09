using Microsoft.AspNetCore.Mvc;
using Module.Core.Data;
using Module.Core.ViewModels;
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
                return Ok(new Response(result));
            }
            return Unauthorized();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody]TokenRefreshRequest request)
        {
            var result = await _tokenService.RefreshAsync(request);
            return Ok(new Response(result));
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke([FromBody]TokenRevokeRequest request)
        {
            var result = await _tokenService.RevokeAsync(request);
            return Ok(new Response(result));
        }

    }
}
