using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;
using static Module.Core.Data.PermissionConstants;

namespace Module.Core.Data
{
    public class RolePermissionSeedProvider : ISeedProvider<RolePermission>
    {
        public int Order => 1;
        public IEnumerable<RolePermission> GetSeeds()
        {
            return new List<RolePermission>
            {
                new RolePermission(1, 1, UserManage),
                new RolePermission(2, 1, RoleManage),
                new RolePermission(3, 1, DesignationManage),
                new RolePermission(4, 1, DepartmentManage),
                new RolePermission(5, 1, ProfileManage),
            };
        }
    }
}
