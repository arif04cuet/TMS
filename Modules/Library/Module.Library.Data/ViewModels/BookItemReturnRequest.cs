using System;

namespace Module.Library.Data
{
    public class BookItemReturnRequest
    {
        public long BookItem { get; set; }
        public bool IsRenew { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public DateTime? NextReturnDate { get; set; }
        public BookItemFineRequest Fine { get; set; }
    }
}
