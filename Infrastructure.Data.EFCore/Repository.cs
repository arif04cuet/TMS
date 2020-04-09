using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Infrastructure.Data.EFCore
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {

        private readonly DbContext _dataContext;

        public Repository(IDataContext dataContext)
        {
            _dataContext = dataContext as DbContext;
        }

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return _dataContext.Set<TEntity>().AddAsync(entity, cancellationToken).AsTask();
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return _dataContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dataContext.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> AsReadOnly()
        {
            return _dataContext.Set<TEntity>().AsQueryable().AsNoTracking();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dataContext.Set<TEntity>().CountAsync(predicate, cancellationToken);
        }

        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dataContext.Set<TEntity>().LongCountAsync(predicate, cancellationToken);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool readOnly = false, CancellationToken cancellationToken = default)
        {
            var set = _dataContext.Set<TEntity>();

            if (readOnly)
                set.AsNoTracking();

            return set.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public TEntity Remove(TEntity entity)
        {
            return _dataContext.Set<TEntity>().Remove(entity).Entity;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dataContext.Set<TEntity>().RemoveRange(entities);
        }

        public void AttachRange(IEnumerable<TEntity> entities)
        {
            _dataContext.Set<TEntity>().AttachRange(entities);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dataContext.SaveChangesAsync(cancellationToken);
        }

        public Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate, bool readOnly = false, CancellationToken cancellationToken = default)
        {
            var set = _dataContext.Set<TEntity>();
            if (readOnly)
                set.AsNoTracking();

            return set.SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool readOnly = false)
        {
            var set = _dataContext.Set<TEntity>();
            if (readOnly)
                set.AsNoTracking();

            return set.Where(predicate);
        }
    }
}
