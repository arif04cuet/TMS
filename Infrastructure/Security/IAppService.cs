namespace Infrastructure.Security
{
    public interface IAppService : IScopedService
    {
        IAuthenticatedUser GetAuthenticatedUser();

        string GetServerUrl();
    }
}
