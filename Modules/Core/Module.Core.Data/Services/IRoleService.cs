using Infrastructure;
using Module.Core.Data.Services;
using Msi.UtilityKit.Pagination;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IRoleService : IIdNameService
    {
        Task<long> CreateAsync(RoleCreateRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(long roleId, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(RoleUpdateRequest request, CancellationToken cancellationToken = default);
    }
}
