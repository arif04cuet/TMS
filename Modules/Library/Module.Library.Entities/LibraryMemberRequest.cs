using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(LibraryMemberRequest), Schema = SchemaConstants.Library)]
    public class LibraryMemberRequest : LibraryEntity
    {
        public long? UserId { get; set; }
        [Searchable]
        public User User { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsApproved { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }

    }
}
