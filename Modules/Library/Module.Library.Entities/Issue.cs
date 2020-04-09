using Infrastructure.Entities;
using Module.Core.Entities;
using System;

namespace Module.Library.Entities
{
    public class Issue : BaseEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public bool IsForLibraryRead { get; set; }

        public long? MemberId { get; set; }
        public User Member { get; set; }

        public long? MemberLibraryCardId { get; set; }
        public MemberLibraryCard MemberLibraryCard { get; set; }

        public DateTimeOffset IssueDate { get; set; }
        public DateTimeOffset ExpireDate { get; set; }
        public DateTimeOffset? ReturnedDate { get; set; }
    }
}
