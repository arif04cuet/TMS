using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Msi.UtilityKit.Security;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Data.Criteria
{
    public class ExistUserByEmailPasswordCriteria : ICriteria<User, bool>
    {
        private readonly string _email;
        private readonly string _password;

        public ExistUserByEmailPasswordCriteria(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public async Task<bool> MatchAsync(IQueryable<User> query, bool readOnly = false)
        {
            var userExists = await query
                .AsNoTracking()
                .Where(x => x.Email.ToLower().Equals(_email.ToLower()) && x.Password == _password.HashPassword())
                .Select(x => x.Id)
                .CountAsync() > 0;
            return userExists;
        }
    }
}
