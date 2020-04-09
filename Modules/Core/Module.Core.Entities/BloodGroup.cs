using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class BloodGroup : IdNameEntity
    {
        public BloodGroup() : base()
        {

        }

        public BloodGroup(long id, string name) : base(id, name)
        {
        }
    }
}
