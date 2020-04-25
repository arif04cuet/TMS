using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
	[Table(nameof(RolePermission), Schema = SchemaConstants.Core)]
	public class RolePermission : IEntity
	{

		public RolePermission()
		{

		}

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