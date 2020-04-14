using Infrastructure.Entities;

namespace Module.Library.Entities
{
    public class BookStatus : IdNameEntity
    {
        public BookStatus() : base()
        {

        }

        public BookStatus(long id, string name) : base(id, name)
        {

        }
    }
}
