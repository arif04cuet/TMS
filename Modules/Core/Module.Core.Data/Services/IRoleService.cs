using Infrastructure;
using Module.Core.Entities;
using Module.Core.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IRoleService : INameCrudService<Role>, IScopedService
    {
        Task<IEnumerable<long>> GetRoleIdsAsync(long userId);

        Task<bool> UpdateRoleAsync(RoleUpdateRequest request, CancellationToken cancellationToken = default);
        Task<long> CreateRoleWithPermissionAsync(RoleUpdateRequest request, CancellationToken cancellationToken = default);

    }
}
