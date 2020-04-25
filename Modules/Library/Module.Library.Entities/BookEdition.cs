using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(BookEdition), Schema = SchemaConstants.Library)]
    public class BookEdition : BaseEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public long? EBookId { get; set; }
        public EBook EBook { get; set; }

        public DateTime PublicationDate { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfCopy { get; set; }
        public string Edition { get; set; }

    }
}
