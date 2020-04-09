using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.EFCore
{
    public class MigratorBase : IMigrator
    {
        public async Task MigratorAsync(IDataContext dataContext, CancellationToken cancellationToken = default)
        {
            await (dataContext as DbContext)?.Database.EnsureCreatedAsync(cancellationToken);
        }
    }
}
