using Infrastructure.Entities;
using Msi.UtilityKit.Search;
using System;

namespace Module.Library.Entities
{
    public class LibraryCard : BaseEntity
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
