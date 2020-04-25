using Infrastructure.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
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

        public UnitOfWork(IDataContext dataContext)
        {
            if (!(dataContext is DbContext))
                throw new ArgumentException($"The {nameof(dataContext)} object must be an instance of the Microsoft.EntityFrameworkCore.DbContext class.");

            _transaction = (dataContext as DbContext).Database.BeginTransaction();
            _dataContext = dataContext;
            _repositories = new Dictionary<Type, object>();
            _dbConnection = (_dataContext as DbContext).Database.GetDbConnection();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            //var entries = _dataContext.GetChangeTrackerEntities<BaseEntity>().ToArray();

            //foreach (var entry in entries)
            //{
            //if (entry.State == EntityState.Modified)
            //{
            //    entry.Entity.SetValue(DateTime.UtcNow, "UpdatedAt");
            //}
            //if (entry.State == EntityState.Added)
            //{
            //    entry.Entity.SetValue(DateTime.UtcNow, "CreatedAt");
            //    entry.Entity.SetValue(DateTime.UtcNow, "UpdatedAt");
            //}
            //}

            var result = (_dataContext as DbContext).SaveChangesAsync(cancellationToken);

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

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_dbConnection.ConnectionString);
        }

        public void Dispose()
        {
            //_dbConnection.Dispose();
            (_dataContext as DbContext).Dispose();
            _transaction.Dispose();
        }
    }
}
