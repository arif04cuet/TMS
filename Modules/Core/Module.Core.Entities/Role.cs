using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
	[Table(nameof(Role), Schema = SchemaConstants.Core)]
	public class Role : IdNameEntity
	{
		public Role() : base()
		{

		}

		public Role(long id, string name) : base(id, name)
		{
		}
	}
}