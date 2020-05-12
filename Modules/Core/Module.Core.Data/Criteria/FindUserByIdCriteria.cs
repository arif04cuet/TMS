using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Data.Criteria
{
    public class FindUserByIdCriteria : ICriteria<User, UserInfoViewModel>
    {
        private readonly long _userId;

        public FindUserByIdCriteria(long userId)
        {
            _userId = userId;
        }

        public async Task<UserInfoViewModel> MatchAsync(IQueryable<User> query, bool readOnly = false)
        {
            var roles = await query
                .AsNoTracking()
                .Where(x => x.Id == _userId && !x.IsDeleted)
                .Select(x => new UserInfoViewModel
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.FullName
                })
                .FirstOrDefaultAsync();
            return roles;
        }
    }
}
