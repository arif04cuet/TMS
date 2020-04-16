using Infrastructure.Entities;

namespace Module.Library.Entities
{
    public class LibraryCardType : IdNameEntity
    {
        public LibraryCardType() : base()
        {

        }

        public LibraryCardType(long id, string name) : base(id, name)
        {
        }
    }
}
