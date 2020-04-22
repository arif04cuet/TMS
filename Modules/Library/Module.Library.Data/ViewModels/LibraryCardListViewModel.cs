using Module.Core.Shared;
using System;

namespace Module.Library.Data
{
    public class LibraryCardListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel CardType { get; set; }
        public float Fees { get; set; }
        public int MaxIssueCount { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
