using Infrastructure.Entities;
using System;

namespace Module.Library.Entities
{
    public class BookEdition : BaseEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Edition { get; set; }
        public int PageCount { get; set; }
        public float Price { get; set; }

    }
}
