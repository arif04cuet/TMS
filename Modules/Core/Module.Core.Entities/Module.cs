using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Module : IdNameEntity
    {
        public Module() : base()
        {

        }

        public Module(long id, string name) : base(id, name)
        {

        }
    }
}
