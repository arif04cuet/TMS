using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class ConsumableCountByIdCriteria : ICriteria<ConsumableUser, int>
    {
        private readonly long _consumableId;

        public ConsumableCountByIdCriteria(long consumableId)
        {
            _consumableId = consumableId;
        }

        public async Task<int> MatchAsync(IQueryable<ConsumableUser> query, bool readOnly = false)
        {
            var count = await query
                .AsNoTracking()
                .Where(x => x.ConsumableId == _consumableId && !x.IsDeleted)
                .Select(x => x.Id)
                .CountAsync();
            return count;
        }
    }
}
