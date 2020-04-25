namespace Infrastructure.Security
{
    public interface IAuthenticatedUser : IScopedService
    {
        long Id { get; set; }
        string Email { get; set; }

        bool IsSuperUser();
    }
}
