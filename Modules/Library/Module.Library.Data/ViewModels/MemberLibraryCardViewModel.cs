using Module.Core.Shared;
using System;

namespace Module.Library.Data
{
    public class MemberLibraryCardViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public IdNameViewModel Card { get; set; }
        public IdNameViewModel Status { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
