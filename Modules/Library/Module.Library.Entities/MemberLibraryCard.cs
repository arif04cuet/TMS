using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(MemberLibraryCard), Schema = SchemaConstants.Library)]
    public class MemberLibraryCard : LibraryEntity
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
