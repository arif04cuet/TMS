using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(PermissionGroup), Schema = SchemaConstants.Core)]
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
