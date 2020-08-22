using Dapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data.Criteria;
using Module.Core.Entities;
using Module.Core.Shared;
using Msi.UtilityKit;
using Msi.UtilityKit.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public class PermissionService : IPermissionService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IRepository<RolePermission> _rolePermissionRepository;
        private readonly IRepository<UserPermission> _userPermissionRepository;

        public PermissionService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _permissionRepository = _unitOfWork.GetRepository<Permission>();
            _rolePermissionRepository = _unitOfWork.GetRepository<RolePermission>();
            _userPermissionRepository = _unitOfWork.GetRepository<UserPermission>();
        }

        public async Task<PagedCollection<ModulePermissionViewModel>> ListAllPermissionsAsync(long? userId, IPagingOptions pagingOptions, CancellationToken cancellationToken = default)
        {
            if (!userId.HasValue)
                userId = 0;

            var roles = await GetRoleIdsAsync((long)userId);

            if (roles.Count() == 0)
                roles = new long[] { 0 };

            var rolesStr = roles.Join(",");

            var sql = $@"select p.*, m.Name ModuleName, pg.Name GroupName,
                            case when up.UserId = {userId.Value} or rp.RoleId in ({rolesStr})
                            then 1 else 0 end as 'Granted'
                        from [core].[Permission] p
                        left join [core].[RolePermission] rp on rp.PermissionId = p.Id
                        left join [core].[UserPermission] up on up.PermissionId = p.Id
                        left join [core].[Module] m on m.Id = p.ModuleId
                        left join [core].[PermissionGroup] pg on pg.Id = p.GroupId
                        order by p.ModuleId asc, p.GroupId asc";
            var permissions = await _unitOfWork.GetConnection()
                .QueryAsync<PermissionDto>(sql);

            var result = CreatePagedCollection(permissions, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<ModulePermissionViewModel>> ListUserPermissionsAsync(long userId, IPagingOptions pagingOptions, CancellationToken cancellationToken = default)
        {
            var sql = $@"select distinct (p.Id), p.Code, p.[Description], p.GroupId, p.ModuleId, p.Name, m.Name ModuleName, pg.Name GroupName,
                            case when up.UserId = @UserId
                            then 1 else 0 end as 'Granted'
                        from [core].[Permission] p
                        left join [core].[UserPermission] up on up.PermissionId = p.Id
                        left join [core].[Module] m on m.Id = p.ModuleId
                        left join [core].[PermissionGroup] pg on pg.Id = p.GroupId
                        order by p.ModuleId asc, p.GroupId asc";
            var permissions = await _unitOfWork.GetConnection()
                .QueryAsync<PermissionDto>(sql, new { UserId = userId });

            var result = CreatePagedCollection(permissions, pagingOptions);
            return result;
        }

        public async Task<PagedCollection<ModulePermissionViewModel>> ListRolePermissionsAsync(long roleId, IPagingOptions pagingOptions, CancellationToken cancellationToken = default)
        {
            var sql = $@"select distinct (p.Id), p.Code, p.[Description], p.GroupId, p.ModuleId, p.Name, m.Name ModuleName, pg.Name GroupName,
                            case when rp.RoleId in (@RoleId)
                            then 1 else 0 end as 'Granted'
                        from [core].[Permission] p
                        left join [core].[RolePermission] rp on rp.PermissionId = p.Id
                        left join [core].[Module] m on m.Id = p.ModuleId
                        left join [core].[PermissionGroup] pg on pg.Id = p.GroupId
                        order by p.ModuleId asc, p.GroupId asc";
            var permissions = await _unitOfWork.GetConnection()
                .QueryAsync<PermissionDto>(sql, new { RoleId = roleId });

            var result = CreatePagedCollection(permissions, pagingOptions);
            return result;
        }

        public async Task<bool> AssignRolePermission(long roleId, ICollection<long> permissions, CancellationToken cancellationToken = default)
        {
            var old = await _rolePermissionRepository
                .Where(x => x.RoleId == roleId)
                .ToListAsync(cancellationToken);

            _rolePermissionRepository.RemoveRange(old);

            var @new = permissions.Select(x => new RolePermission
            {
                PermissionId = x,
                RoleId = roleId
            });
            await _rolePermissionRepository.AddRangeAsync(@new, cancellationToken);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> AssignUserPermission(long userId, ICollection<long> permissions, CancellationToken cancellationToken = default)
        {
            var old = await _userPermissionRepository
                .Where(x => x.UserId == userId)
                .ToListAsync(cancellationToken);

            _userPermissionRepository.RemoveRange(old);

            var @new = permissions.Select(x => new UserPermission
            {
                PermissionId = x,
                UserId = userId
            });

            await _userPermissionRepository.AddRangeAsync(@new, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> Check(long userId, string permissioCode)
        {
            var roleIds = await GetRoleIdsAsync(userId);
            return false;
        }

        public async Task<IEnumerable<CheckPermissionViewModel>> CheckPermissions(CheckPermissionRequest request)
        {
            if (!request.UserId.HasValue)
                request.UserId = 0;

            var roles = await GetRoleIdsAsync((long)request.UserId);

            if (roles.Count() == 0)
                roles = new long[] { 0 };

            var rolesStr = roles.Join(",");
            var codes = request.Permissions != null && request.Permissions.Count() > 0 ? request.Permissions.Select(x => "\'" + x + "\'").Join(",") : "";

            var sql = $@"select p.Id, p.Code,
                            case when p.Code in ({codes}) and (up.UserId = {request.UserId.Value} or rp.RoleId in ({rolesStr}))
                            then 1 else 0 end as 'Granted'
                        from [core].[Permission] p
                        left join [core].[RolePermission] rp on rp.PermissionId = p.Id
                        left join [core].[UserPermission] up on up.PermissionId = p.Id
                        where p.Code in ({codes})";

            var result = await _unitOfWork.GetConnection()
                .QueryAsync<CheckPermissionViewModel>(sql);

            return result;
        }

        private PagedCollection<ModulePermissionViewModel> CreatePagedCollection(IEnumerable<PermissionDto> permissions, IPagingOptions pagingOptions)
        {
            List<ModulePermissionViewModel> modulePermissions = new List<ModulePermissionViewModel>();

            long? currentModule = 0;
            long currentGroup = 0;
            long currentPermission = 0;

            var module = new ModulePermissionViewModel();
            var group = new GroupPermissionViewModel();
            var permission = new PermissionViewModel();

            foreach (var item in permissions)
            {
                if (currentModule != item.ModuleId)
                {
                    currentModule = item.ModuleId;
                    module = new ModulePermissionViewModel();
                    module.Module = new IdNameViewModel { Id = item.GroupId, Name = item.ModuleName };
                    module.Groups = new List<GroupPermissionViewModel>();
                    modulePermissions.Add(module);
                }
                if (currentGroup != item.GroupId)
                {
                    currentGroup = item.GroupId;
                    group = new GroupPermissionViewModel();
                    group.Group = new IdNameViewModel { Id = item.GroupId, Name = item.GroupName };
                    group.Permissions = new List<PermissionViewModel>();
                    module.Groups.Add(group);
                }
                if (currentPermission != item.Id)
                {
                    currentPermission = item.Id;
                    permission = new PermissionViewModel();
                }
                permission.Id = item.Id;
                permission.Code = item.Code;
                permission.Granted = item.Granted;
                permission.Name = item.Name;
                group.Permissions.Add(permission);
            }

            int total = permissions.Count();

            var result = new PagedCollection<ModulePermissionViewModel>(modulePermissions, total, pagingOptions);

            return result;
        }

        private async Task<IEnumerable<long>> GetRoleIdsAsync(long userId)
        {
            var roles = await _unitOfWork.GetRepository<UserRole>().MatchAsync(new FindRoleIdsByUserIdCriteria(userId));
            return roles;
        }
    }
}
