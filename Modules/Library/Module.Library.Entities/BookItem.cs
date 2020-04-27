using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(BookItem), Schema = SchemaConstants.Library)]
    public class BookItem : LibraryEntity
    {
        public float PurchagePrice { get; set; }
        [Searchable]
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

        public long? CurrentIssueId { get; set; }
        [ForeignKey(nameof(CurrentIssueId))]
        public BookIssue CurrentIssue { get; set; }

        public long? ReservedForId { get; set; }
        public virtual User ReservedFor { get; set; }

    }
}
