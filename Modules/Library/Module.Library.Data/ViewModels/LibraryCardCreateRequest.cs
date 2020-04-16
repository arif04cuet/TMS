using System;

namespace Module.Library.Data
{
    public class LibraryCardCreateRequest
    {
        public string CardNumber { get; set; }
        public long CardTypeId { get; set; }
        public float Fees { get; set; }
        public int MaxIssueCount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
