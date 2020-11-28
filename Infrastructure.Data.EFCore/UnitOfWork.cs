using Infrastructure.Entities;
using Infrastructure.Security;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Msi.UtilityKit;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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

        private static ConcurrentDictionary<Type, List<PropertyInfo>> _uniqueFields = new ConcurrentDictionary<Type, List<PropertyInfo>>();
        private static MethodInfo[] QueryableMethods = typeof(Queryable).GetMethods().ToArray();

        private static MethodInfo WhereMethod(Type type) => QueryableMethods
            .First(x => x.Name == "Where" && x.GetParameters().Length == 2)
            .MakeGenericMethod(new[] { type });

        private static MethodInfo CountMethod = QueryableMethods.First(x => x.Name == "Count" && x.GetParameters().Length == 1);

        private static MethodInfo AsQueryableMethod => typeof(Queryable).GetMethod("AsQueryable", new Type[] { typeof(IEnumerable<>) });

        private static MethodInfo DbSetMethod(DbContext dbContext, Type type) => dbContext.GetType().GetMethod("Set").MakeGenericMethod(type);

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

                // unique validation
                if (entry.State == EntityState.Modified
                    || entry.State == EntityState.Added
                    || entry.State == EntityState.Unchanged)
                {
                    var type = entry.Entity.GetType();
                    List<PropertyInfo> props = new List<PropertyInfo>();
                    if (_uniqueFields.ContainsKey(type))
                    {
                        _uniqueFields.TryGetValue(type, out props);
                    }
                    else
                    {
                        var uniqueAttribute = type.GetCustomAttribute<CheckUniqueAttribute>();
                        if (uniqueAttribute != null)
                        {
                            var _props = type.GetProperties().Where(x => x.GetCustomAttribute<UniqueFieldAttribute>(true) != null).ToList();
                            if (_props.Count > 0)
                            {
                                _uniqueFields.TryAdd(type, _props);
                                props = _props;
                            }
                        }
                    }
                    if (props.Count > 0)
                    {
                        var set = DbSetMethod(_dbContext, type).Invoke(_dbContext, null);
                        var query = AsQueryableMethod.Invoke(null, new object[] { set });

                        // build up the LINQ expression backwards:
                        // query = query.Where(x => x.Property == "Value");

                        var parameter = Expression.Parameter(type);

                        foreach (var prop in props)
                        {
                            // x.Property
                            var left = parameter.GetPropertyExpression(prop);

                            // "Value"
                            var right = Expression.Constant(entry.Entity.GetValue(prop.Name), prop.PropertyType);

                            // x.Property == "Value"
                            var expression = Expression.Equal(left, right);

                            // x => x.Property == "Value"
                            var lambda = ExpressionUtilities
                                .GetLambda(type, typeof(bool), parameter, expression);

                            // query = query.Where...
                            query = WhereMethod(type)
                                .Invoke(null, new object[] { query, lambda });
                        }

                        var count = (int)CountMethod
                            .MakeGenericMethod(type)
                            .Invoke(null, new object[] { query });
                        if(count > 0)
                        {
                            throw new ValidationException($"Item already exist.");
                        }
                    }
                }

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
