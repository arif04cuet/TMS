﻿using Infrastructure.Entities;
using System;

namespace Module.Library.Entities
{
    /// <summary>
    /// Library card is which that is consumed by library members. One member can have multiple cards.
    /// </summary>
    public class LibraryCard : BaseEntity
    {
        public string CardNumber { get; set; }

        // Type can be Silver, Gold, Platinum etc
        
        public long CardTypeId { get; set; }

        public float Fees { get; set; } // anoter entity with year relatuion
        public int MaxIssueCount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
