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
        public string Name { get; set; }

        [Searchable]
        public long CardTypeId { get; set; }
        public LibraryCardType CardType { get; set; }

        public float Fees { get; set; }
        public int MaxIssueCount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
