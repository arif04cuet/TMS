using Infrastructure.Entities;

namespace Module.Library.Entities
{
    public class BookAuthor : IEntity
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public Book Book { get; set; }

        public long AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
