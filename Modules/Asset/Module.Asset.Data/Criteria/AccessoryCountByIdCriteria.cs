using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class AccessoryCountByIdCriteria : ICriteria<AccessoryUser, int>
    {
        private readonly long _id;

        public AccessoryCountByIdCriteria(long id)
        {
            _id = id;
        }

        public async Task<int> MatchAsync(IQueryable<AccessoryUser> query, bool readOnly = false)
        {
            var count = await query
                .AsNoTracking()
                .Where(x => x.AccessoryId == _id && !x.IsDeleted)
                .Select(x => x.Id)
                .CountAsync();
            return count;
        }
    }
}
