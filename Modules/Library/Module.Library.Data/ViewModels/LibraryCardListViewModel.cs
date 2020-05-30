using Module.Core.Shared;
using System;

namespace Module.Library.Data
{
    public class LibraryCardListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Barcode { get; set; }
        public IdNameViewModel CardType { get; set; }
        public IdNameViewModel Member { get; set; }
        public IdNameViewModel Status { get; set; }
        public float CardFee { get; set; }
        public float LateFee { get; set; }
        public int MaxIssueCount { get; set; }
        public DateTime? ExpireDate { get; set; }

    }
}
