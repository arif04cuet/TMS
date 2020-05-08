using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Data.Criteria
{
    public class ExistUserByIdCriteria : ICriteria<User, bool>
    {
        private readonly long _id;

        public ExistUserByIdCriteria(long id)
        {
            _id = id;
        }

        public async Task<bool> MatchAsync(IQueryable<User> query, bool readOnly = false)
        {
            var userExists = await query
                .AsNoTracking()
                .Where(x => x.Id == _id && !x.IsDeleted)
                .Select(x => x.Id)
                .CountAsync() > 0;
            return userExists;
        }
    }
}
