using Infrastructure.Entities;

namespace Module.Core.Entities
{
	public class RolePermission : IEntity
	{

		public RolePermission(long id, long roleId, long permissionId)
		{
			Id = id;
			RoleId = roleId;
			PermissionId = permissionId;
		}

		public long Id { get; set; }

		public long RoleId { get; set; }
		public Role Role { get; set; }

		public long PermissionId { get; set; }
		public Permission Permission { get; set; }
	}
}