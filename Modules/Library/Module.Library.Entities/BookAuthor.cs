using Infrastructure.Entities;

namespace Module.Library.Entities
{
    public class BookAuthor : BaseEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public long AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
