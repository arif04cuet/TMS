using Infrastructure.Entities;
using System;

namespace Module.Library.Entities
{
    /// <summary>
    /// Library card is which that is consumed by library members. One member can have multiple cards.
    /// </summary>
    public class LibraryCard : BaseEntity
    {
        public string Type { get; set; }
        public float Fees { get; set; }
        public int MaxReadIssueCount { get; set; }
        public int MaxLendIssueCount { get; set; }
        public DateTimeOffset ExpireDate { get; set; }
    }
}
