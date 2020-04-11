using Infrastructure.Entities;

namespace Module.Core.Entities
{
	public class UserPermission : IEntity
	{
		public long Id { get; set; }

		public long UserId { get; set; }
		public User User { get; set; }

		public long PermissionId { get; set; }
		public Permission Permission { get; set; }
	}
}