using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class ComponentCountByIdCriteria : ICriteria<ComponentAsset, int>
    {
        private readonly long _componentId;

        public ComponentCountByIdCriteria(long consumableId)
        {
            _componentId = consumableId;
        }

        public async Task<int> MatchAsync(IQueryable<ComponentAsset> query, bool readOnly = false)
        {
            var count = await query
                .AsNoTracking()
                .Where(x => x.ComponentId == _componentId && !x.IsDeleted)
                .Select(x => x.Id)
                .CountAsync();
            return count;
        }
    }
}
