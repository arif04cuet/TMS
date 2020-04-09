using Infrastructure.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public interface ISeedProvider<out TEntity> where TEntity : IEntity
    {
        int Order { get; }

        IEnumerable<TEntity> GetSeeds();
    }
}
