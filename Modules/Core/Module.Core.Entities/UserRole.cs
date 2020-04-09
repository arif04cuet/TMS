using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class UserRole : BaseEntity
    {

        public long UserId { get; set; }
        public User User { get; set; }

        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}