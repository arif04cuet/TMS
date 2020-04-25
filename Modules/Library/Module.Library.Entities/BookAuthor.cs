using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(BookAuthor), Schema = SchemaConstants.Library)]
    public class BookAuthor : BaseEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public long AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
