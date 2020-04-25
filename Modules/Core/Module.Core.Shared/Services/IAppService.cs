using Infrastructure;
using Infrastructure.Security;

namespace Module.Core.Shared
{
    public interface IAppService : IScopedService
    {
        IAuthenticatedUser GetAuthenticatedUser();

        string GetServerUrl();
    }
}
