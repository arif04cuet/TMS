using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;
using static Module.Core.Shared.PermissionGroupConstants;

namespace Module.Core.Data
{
    public class PermissionGroupSeedProvider : ISeedProvider<PermissionGroup>
    {
        public int Order => 0;
        public IEnumerable<PermissionGroup> GetSeeds()
        {
            return new List<PermissionGroup>
            {
                new PermissionGroup(UserGroup, "User"),
                new PermissionGroup(RoleGroup, "Role"),
                new PermissionGroup(DesignationGroup, "Designation"),
                new PermissionGroup(DepartmentGroup, "Department"),
                new PermissionGroup(ProfileGroup, "Profile"),
                new PermissionGroup(BookGroup, "Book"),
            };
        }
    }
}
