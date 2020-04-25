using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(Library), Schema = SchemaConstants.Library)]
    public class Library : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }
        public long? AddressId { get; set; }
        public Address Address { get; set; }

        [Searchable]
        public long? LibrarianId { get; set; }
        public User Librarian { get; set; }
    }
}
