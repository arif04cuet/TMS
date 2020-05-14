using Infrastructure.Security;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security
{
    public class AppService : IAppService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly HttpRequest _request;

        public AppService(
            IHttpContextAccessor httpContextAccessor,
            IAuthenticatedUser authenticatedUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticatedUser = authenticatedUser;
            _request = _httpContextAccessor.HttpContext.Request;
        }

        public string GetServerUrl()
        {
            string url = $"{_request.Scheme}://{_request.Host}";
            return url;
        }

        public IAuthenticatedUser GetAuthenticatedUser()
        {
            return _authenticatedUser;
        }


    }
}
