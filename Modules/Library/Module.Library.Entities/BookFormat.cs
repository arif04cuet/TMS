using Infrastructure.Entities;

namespace Module.Library.Entities
{
    public class BookFormat : IdNameEntity
    {
        public BookFormat() : base()
        {

        }

        public BookFormat(long id, string name) : base(id, name)
        {

        }
    }
}
