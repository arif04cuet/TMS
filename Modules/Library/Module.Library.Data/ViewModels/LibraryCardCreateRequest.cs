using System;

namespace Module.Library.Data
{
    public class LibraryCardCreateRequest
    {
        public string Name { get; set; }
        public long CardType { get; set; }
        public float Fees { get; set; }
        public int MaxIssueCount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
