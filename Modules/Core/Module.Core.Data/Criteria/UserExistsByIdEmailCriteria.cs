using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Data.Criteria
{
    public class UserExistsByIdEmailCriteria : ICriteria<User, bool>
    {
        private readonly long _id;
        private readonly string _email;

        public UserExistsByIdEmailCriteria(long id, string email)
        {
            _id = id;
            _email = email;
        }

        public async Task<bool> MatchAsync(IQueryable<User> query, bool readOnly = false)
        {
            var userExists = await query
                .AsNoTracking()
                .Where(x => x.Email.ToLower().Equals(_email.ToLower()) && x.Id == _id)
                .Select(x => x.Id)
                .CountAsync() > 0;
            return userExists;
        }
    }
}
