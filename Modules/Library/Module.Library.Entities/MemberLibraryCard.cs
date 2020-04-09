using Infrastructure.Entities;
using Module.Core.Entities;

namespace Module.Library.Entities
{
    public class MemberLibraryCard : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long LibraryCardId { get; set; }
        public LibraryCard LibraryCard { get; set; }
    }
}
