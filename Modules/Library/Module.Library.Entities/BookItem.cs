using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using System;

namespace Module.Library.Entities
{
    public class BookItem : BaseEntity
    {
        public float PurchagePrice { get; set; }
        public string Isbn { get; set; }
        public string Barcode { get; set; }

        public long BookId { get; set; }
        [Searchable]
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

        public long? IssuedToId { get; set; }
        public virtual User IssuedTo { get; set; }

        public long? ReservedForId { get; set; }
        public virtual User ReservedFor { get; set; }

    }
}
