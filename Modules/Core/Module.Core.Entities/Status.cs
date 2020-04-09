using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Status : IdNameEntity
    {
        public Status()
        {

        }

        public Status(long id, string name) : base(id, name)
        {
        }
    }
}
