using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class ExistAssetByIdCriteria : ICriteria<Entities.Asset, bool>
    {
        private readonly long _assetId;

        public ExistAssetByIdCriteria(long assetId)
        {
            _assetId = assetId;
        }

        public async Task<bool> MatchAsync(IQueryable<Entities.Asset> query, bool readOnly = false)
        {
            var exist = await query
                .AsNoTracking()
                .Where(x => x.Id == _assetId && !x.IsDeleted)
                .Select(x => x.Id)
                .CountAsync() > 0;
            return exist;
        }
    }
}
