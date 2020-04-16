using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Library.Entities
{
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
