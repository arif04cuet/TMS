using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class District : IdNameEntity
    {        
        public District() : base()
        {

        }

        public District(long id, string name) : base(id, name)
        {
        }
    }
}
