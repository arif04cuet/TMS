using Infrastructure.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface ICriteria<TEntity, TResponse>
        where TEntity : IEntity
    {

        Task<TResponse> MatchAsync(IQueryable<TEntity> query, bool readOnly = false);

    }
}
