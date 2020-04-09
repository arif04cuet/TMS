using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class PermissionGroup : IdNameEntity
    {
        public PermissionGroup() : base()
        {

        }

        public PermissionGroup(long id, string name) : base (id, name)
        {
        }
    }
}
