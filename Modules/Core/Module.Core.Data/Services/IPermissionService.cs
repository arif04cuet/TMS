using Infrastructure;
using Msi.UtilityKit.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IPermissionService : IScopedService
    {
        Task<PagedCollection<IdNameViewModel>> ListAsync(IPagingOptions pagingOptions, CancellationToken cancellationToken = default);
    }
}
