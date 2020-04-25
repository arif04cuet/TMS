using Infrastructure;
using Msi.UtilityKit.Pagination;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public interface IPermissionService : IScopedService
    {
        Task<PagedCollection<ModulePermissionViewModel>> ListAllPermissionsAsync(long? userId, IPagingOptions pagingOptions, CancellationToken cancellationToken = default);

        Task<PagedCollection<ModulePermissionViewModel>> ListUserPermissionsAsync(long userId, IPagingOptions pagingOptions, CancellationToken cancellationToken = default);

        Task<PagedCollection<ModulePermissionViewModel>> ListRolePermissionsAsync(long roleId, IPagingOptions pagingOptions, CancellationToken cancellationToken = default);

        Task<bool> AssignRolePermission(long roleId, ICollection<long> permissions, CancellationToken cancellationToken = default);

        Task<bool> AssignUserPermission(long userId, ICollection<long> permissions, CancellationToken cancellationToken = default);

        Task<IEnumerable<CheckPermissionViewModel>> CheckPermissions(CheckPermissionRequest request);
    }
}
