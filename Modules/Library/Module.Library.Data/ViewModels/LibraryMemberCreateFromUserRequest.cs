using System;

namespace Module.Library.Data
{
    public class LibraryMemberCreateFromUserRequest
    {
        public long User { get; set; }
        public long Library { get; set; }
        public DateTime? MemberSince { get; set; }
        public MemberLibraryCardRequest Card { get; set; }
    }
}
