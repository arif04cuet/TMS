using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(BookSubject), Schema = SchemaConstants.Library)]
    public class BookSubject : IdNameEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
