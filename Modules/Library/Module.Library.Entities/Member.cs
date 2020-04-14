using Infrastructure.Entities;
using Module.Core.Entities;
using System;

namespace Module.Library.Entities
{
    public class Member : BaseEntity
    {

        public long LibraryId { get; set; }
        public Library Library { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public DateTime MemberSince { get; set; }

        public long TotalBooksCheckout { get; set; }
        public bool Blocked { get; set; } // should be user blocked also
    }
}
