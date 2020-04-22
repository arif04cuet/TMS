using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using System;

namespace Module.Library.Entities
{
    public class LibraryMember : BaseEntity
    {
        [Searchable]
        public long LibraryId { get; set; }
        public Library Library { get; set; }

        public long UserId { get; set; }
        [Searchable]
        public User User { get; set; }

        public DateTime MemberSince { get; set; }

        public long TotalBooksCheckout { get; set; }
        public bool Blocked { get; set; }
    }
}
