namespace Infrastructure.Security
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public long Id { get; set; }
        public string Email { get; set; }

        public AuthenticatedUser(IAuthenticatedUserProvider provider)
        {
            provider.Populate(this);
        }

        public bool IsSuperUser()
        {
            return Id == 1 && Email.Equals("admin@gmail.com");
        }
    }
}
