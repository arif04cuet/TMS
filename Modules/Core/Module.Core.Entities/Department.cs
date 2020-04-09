using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Department : IdNameEntity
    {
        public Department() : base()
        {

        }

        public Department(long id, string name) : base(id, name)
        {

        }
    }
}
