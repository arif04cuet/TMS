using Infrastructure.Entities;
using Module.Core.Entities;
using System;

namespace Module.Library.Entities
{
    public class MemberLibraryCard : BaseEntity
    {
        public string CardNumber { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }

        public long LibraryCardId { get; set; }
        public LibraryCard LibraryCard { get; set; }

        public long CardStatusId { get; set; }
        public LibraryCardStatus CardStatus { get; set; }

        public DateTime CardExpireDate { get; set; }
    }
}
