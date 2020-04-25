using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security
{
    public class AuthenticatedUserProvider : IAuthenticatedUserProvider
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticatedUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Populate(IAuthenticatedUser authenticatedUser)
        {
            if (_httpContextAccessor.HttpContext == null) return;

            var currentUser = _httpContextAccessor.HttpContext.User;

            foreach (var claim in currentUser.Claims)
            {
                switch (claim.Type)
                {
                    case ClaimTypeConstants.UserIdKey:
                        authenticatedUser.Id = long.Parse(claim.Value);
                        break;
                    case ClaimTypeConstants.UserEmailKey:
                        authenticatedUser.Email = claim.Value;
                        break;
                }
            }
        }
    }
}
