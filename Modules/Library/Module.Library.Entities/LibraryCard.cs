using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(LibraryCard), Schema = SchemaConstants.Library)]
    public class LibraryCard : LibraryEntity
    {
        [Searchable]
        public string Barcode { get; set; }

        [Searchable]
        public long CardTypeId { get; set; }
        [Searchable]
        public LibraryCardType CardType { get; set; }

        public float CardFee { get; set; }
        public float LateFee { get; set; }
        public int MaxIssueCount { get; set; }
        public DateTime? ExpireDate { get; set; }

        [Searchable]
        public long? MemberId { get; set; }
        public User Member { get; set; }

        [Searchable]
        public long? CardStatusId { get; set; }
        public LibraryCardStatus CardStatus { get; set; }

        public long? PhotoId { get; set; }
        public Media Photo { get; set; }
    }
}
