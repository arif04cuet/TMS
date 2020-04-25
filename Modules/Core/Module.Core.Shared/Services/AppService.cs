using Infrastructure.Security;
using Microsoft.AspNetCore.Http;

namespace Module.Core.Shared
{
    public class AppService : IAppService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthenticatedUser _authenticatedUser;

        public AppService(
            IHttpContextAccessor httpContextAccessor,
            IAuthenticatedUser authenticatedUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticatedUser = authenticatedUser;
        }

        public string GetServerUrl()
        {
            string url = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.ToString()}";
            return url;
        }

        public IAuthenticatedUser GetAuthenticatedUser()
        {
            return _authenticatedUser;
        }


    }
}
