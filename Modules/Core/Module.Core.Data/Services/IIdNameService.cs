using Infrastructure;
using Msi.UtilityKit.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data.Services
{
    public interface IIdNameService : IScopedService
    {
        Task<IdNameViewModel> Get(long id, CancellationToken cancellationToken = default);

        Task<PagedCollection<IdNameViewModel>> ListAsync(IPagingOptions pagingOptions, CancellationToken cancellationToken = default);
    }
}
