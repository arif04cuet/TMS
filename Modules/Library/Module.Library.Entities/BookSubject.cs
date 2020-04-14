using Infrastructure.Entities;

namespace Module.Library.Entities
{
    public class BookSubject : IdNameEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
