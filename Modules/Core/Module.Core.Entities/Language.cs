using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Language : IdNameEntity
    {
        public Language() : base()
        {

        }

        public Language(long id, string name) : base(id, name)
        {
        }
    }
}
