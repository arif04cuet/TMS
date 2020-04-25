using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Permission), Schema = SchemaConstants.Core)]
    public class Permission : IEntity
    {

        public Permission()
        {

        }

        public Permission(long id, string name, string code, long groupId, long? moduleId)
        {
            Id = id;
            Name = name;
            Code = code;
            GroupId = groupId;
            ModuleId = moduleId;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public long GroupId { get; set; }
        public PermissionGroup Group { get; set; }

        public long? ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
