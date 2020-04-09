using Infrastructure.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IUnitOfWork<TDataContext> where TDataContext : IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<TSet> GetRepository<TSet>() where TSet : class, IEntity;
    }
}
