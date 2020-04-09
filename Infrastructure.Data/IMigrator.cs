using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IMigrator
    {
        Task MigratorAsync(IDataContext dataContext, CancellationToken cancellationToken = default);
    }
}
