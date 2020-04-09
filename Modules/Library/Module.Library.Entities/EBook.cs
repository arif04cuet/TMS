using Infrastructure.Entities;

namespace Module.Library.Entities
{
    public class EBook : IEntity
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public Book Book { get; set; }

        public string Link { get; set; }
        public Format Format { get; set; }

    }
}
