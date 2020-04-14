using Infrastructure.Entities;
using System;

namespace Module.Library.Entities
{
    public class BookItem : BaseEntity
    {
        public float Price { get; set; }
        public string Barcode { get; set; }

        public long BookId { get; set; }
        public Book Book { get; set; }

        public long? FormatId { get; set; }
        public BookFormat Format { get; set; }

        public long? StatusId { get; set; }
        public BookStatus Status { get; set; }

        public long? RackId { get; set; }
        public Rack Rack { get; set; }

        public long? EditionId { get; set; }
        public BookEdition Edition { get; set; }

        public DateTime? DateOfPurchage { get; set; }

    }
}
