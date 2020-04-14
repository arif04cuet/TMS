using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Core.Data
{

    public class PermissionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public long? ModuleId { get; set; }
        public string ModuleName { get; set; }
        public bool Granted { get; set; }
    }

    public class PermissionViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Granted { get; set; }
    }

    public class ModulePermissionViewModel
    {
        public IdNameViewModel Module { get; set; }
        public ICollection<GroupPermissionViewModel> Groups { get; set; }
    }

    public class GroupPermissionViewModel
    {
        public IdNameViewModel Group { get; set; }
        public ICollection<PermissionViewModel> Permissions { get; set; }
    }


}
