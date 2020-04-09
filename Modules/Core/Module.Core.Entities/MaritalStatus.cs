using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class MaritalStatus : IdNameEntity
    {
        public MaritalStatus() : base()
        {

        }

        public MaritalStatus(long id, string name) : base(id, name)
        {
        }
    }
}
