using Infrastructure;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface ITokenService : IScopedService
    {
        Task<TokenViewModel> CreateAsync(long userId);

        Task<TokenViewModel> CreateAsync(TokenCreateRequest request);

        Task<TokenViewModel> RefreshAsync(TokenRefreshRequest request);

        Task<bool> RevokeAsync(TokenRevokeRequest request);

        Task<bool> CreateForgotPasswordToken(ForgotPasswordRequest request);

        Task<bool> ResetPasswordAsync(ResetPasswordRequest request);
    }
}
