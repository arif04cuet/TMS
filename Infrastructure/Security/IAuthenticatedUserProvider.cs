namespace Infrastructure.Security
{
    public interface IAuthenticatedUserProvider : IScopedService
    {
        void Populate(IAuthenticatedUser authenticatedUser);
    }
}
