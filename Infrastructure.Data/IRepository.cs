using Infrastructure;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicatebool, bool readOnly = false);

        TEntity Remove(TEntity entity);

        void AttachRange(IEnumerable<TEntity> entities);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        //Task<bool> ExistAsync(long id);

        //bool Exist(long? id);

        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate, bool readOnly = false, CancellationToken cancellationToken = default);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool readOnly = false, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IQueryable<TEntity> AsQueryable();

        IQueryable<TEntity> AsReadOnly();
    }
}
