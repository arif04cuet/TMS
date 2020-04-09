using Infrastructure.Entities;
using System.Linq;

namespace Infrastructure.Data
{
    public interface ICriteria<TEntity, TResponse>
        where TEntity : IEntity
    {

        IQueryable<TResponse> Match(IQueryable<TEntity> query, bool readOnly = false);

    }
}
