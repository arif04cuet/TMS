using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
	[Table(nameof(UserPermission), Schema = SchemaConstants.Core)]
	public class UserPermission : IEntity
	{
		public long Id { get; set; }

		public long UserId { get; set; }
		public User User { get; set; }

		public long PermissionId { get; set; }
		public Permission Permission { get; set; }
	}
}