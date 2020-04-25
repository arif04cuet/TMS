using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(LibraryMember), Schema = SchemaConstants.Library)]
    public class LibraryMember : LibraryEntity
    {
        public long UserId { get; set; }
        [Searchable]
        public User User { get; set; }

        public DateTime MemberSince { get; set; }

        public long TotalBooksCheckout { get; set; }
        public bool Blocked { get; set; }
    }
}
