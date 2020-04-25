using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using Module.Core.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Data.Criteria
{
    public class RolesByUserIdCriteria : ICriteria<UserRole, ICollection<IdNameViewModel>>
    {
        private readonly long _userId;

        public RolesByUserIdCriteria(long userId)
        {
            _userId = userId;
        }

        public async Task<ICollection<IdNameViewModel>> MatchAsync(IQueryable<UserRole> query, bool readOnly = false)
        {
            var roles = await query
                .AsNoTracking()
                .Where(x => x.UserId == _userId && !x.IsDeleted)
                .Select(x => new IdNameViewModel
                {
                    Id = x.RoleId,
                    Name = x.Role.Name
                })
                .ToListAsync();
            return roles;
        }
    }
}
