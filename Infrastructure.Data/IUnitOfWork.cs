using Infrastructure.Entities;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<TSet> GetRepository<TSet>() where TSet : class, IEntity;

        Task CommitAsync(CancellationToken cancellationToken = default);

        IDbConnection GetConnection();
    }
}
