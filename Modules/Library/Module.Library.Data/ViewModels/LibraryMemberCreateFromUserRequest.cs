using System;

namespace Module.Library.Data
{
    public class LibraryMemberCreateFromUserRequest
    {
        public long User { get; set; }
        public long Library { get; set; }
        public DateTime? MemberSince { get; set; }

        public long CardId { get; set; }
        public DateTime CardExpireDate { get; set; }

        public long? Photo { get; set; }
    }
}
