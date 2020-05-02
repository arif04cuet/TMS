using System;

namespace Module.Library.Data
{
    public class LibraryCardCreateRequest
    {
        public long NumberOfCopy { get; set; }
        public long CardType { get; set; }
        public float Fees { get; set; }
        public int MaxIssueCount { get; set; }
        public DateTime ExpireDate { get; set; }
        public long StatusId { get; set; }
        public long? LibraryId { get; set; }
    }
}
