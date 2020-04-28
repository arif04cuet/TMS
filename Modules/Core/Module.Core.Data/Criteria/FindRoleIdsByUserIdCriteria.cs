using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Data.Criteria
{
    public class FindRoleIdsByUserIdCriteria : ICriteria<UserRole, List<long>>
    {
        private readonly long _userId;

        public FindRoleIdsByUserIdCriteria(long userId)
        {
            _userId = userId;
        }

        public async Task<List<long>> MatchAsync(IQueryable<UserRole> query, bool readOnly = false)
        {
            var roles = await query
                .AsNoTracking()
                .Where(x => x.UserId == _userId && !x.IsDeleted)
                .Select(x => x.RoleId)
                .ToListAsync();
            return roles;
        }
    }
}
