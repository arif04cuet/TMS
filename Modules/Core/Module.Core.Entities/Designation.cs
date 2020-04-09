using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Designation : IdNameEntity
    {
        public Designation() : base()
        {

        }

        public Designation(long id, string name) : base(id, name)
        {

        }
    }
}
