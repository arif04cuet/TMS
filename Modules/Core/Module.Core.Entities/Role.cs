using Infrastructure.Entities;

namespace Module.Core.Entities
{
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