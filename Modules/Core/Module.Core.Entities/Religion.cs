using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Religion : IdNameEntity
    {

        public Religion() : base()
        {

        }

        public Religion(long id, string name) : base(id, name)
        {
        }
    }
}
