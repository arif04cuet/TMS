using Infrastructure.Entities;
using Infrastructure.Security;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.EFCore
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly IDataContext _dataContext;
        private readonly Dictionary<Type, object> _repositories;
        private readonly IDbContextTransaction _transaction;
        private readonly IDbConnection _dbConnection;
        private readonly DbContext _dbContext;
        private readonly IAuthenticatedUser _authenticatedUser;

        public UnitOfWork(
            IDataContext dataContext,
            IAuthenticatedUser authenticatedUser)
        {
            if (!(dataContext is DbContext))
                throw new ArgumentException($"The {nameof(dataContext)} object must be an instance of the Microsoft.EntityFrameworkCore.DbContext class.");

            _transaction = (dataContext as DbContext).Database.BeginTransaction();
            _dataContext = dataContext;
            _dbContext = _dataContext as DbContext;
            _repositories = new Dictionary<Type, object>();
            _dbConnection = _dbContext.Database.GetDbConnection();
            _authenticatedUser = authenticatedUser;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = _dbContext.ChangeTracker.Entries<BaseEntity>().ToArray();
            foreach (var entry in entries)
            {
                var entity = entry.Entity;
                if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedBy = _authenticatedUser?.Id;
                    entity.UpdatedAt = DateTime.UtcNow;
                }
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = _authenticatedUser?.Id;
                    entity.CreatedAt = DateTime.UtcNow;
                    entity.UpdatedAt = DateTime.UtcNow;
                }
            }
            var result = _dbContext.SaveChangesAsync(cancellationToken);
            return result;
        }

        public IRepository<TSet> GetRepository<TSet>() where TSet : class, IEntity
        {
            if (_repositories.ContainsKey(typeof(TSet)))
            {
                return _repositories[typeof(TSet)] as IRepository<TSet>;
            }

            var repository = new Repository<TSet>(_dataContext);
            _repositories.Add(typeof(TSet), repository);
            return repository;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await _transaction.RollbackAsync(cancellationToken);
            }
        }

        public Task RollBackAsync(CancellationToken cancellationToken = default)
        {
            return _transaction.RollbackAsync(cancellationToken);
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_dbConnection.ConnectionString);
        }

        public void Dispose()
        {
            //_dbConnection.Dispose();
            _dbContext.Dispose();
            _transaction.Dispose();
        }
    }
}
