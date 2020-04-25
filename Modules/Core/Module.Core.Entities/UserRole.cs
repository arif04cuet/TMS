using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(UserRole), Schema = SchemaConstants.Core)]
    public class UserRole : BaseEntity
    {

        public long UserId { get; set; }
        public User User { get; set; }

        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}