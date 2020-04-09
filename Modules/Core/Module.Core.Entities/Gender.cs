using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Gender : IdNameEntity
    {
        public Gender() : base()
        {

        }

        public Gender(long id, string name) : base (id, name)
        {
            Id = id;
            Name = name;
        }
    }
}
