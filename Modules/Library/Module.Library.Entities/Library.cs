using Infrastructure.Entities;
using Module.Core.Entities;

namespace Module.Library.Entities
{
    public class Library : BaseEntity
    {
        public string Name { get; set; }
        public long? AddressId { get; set; }
        public Address Address { get; set; }

        public long? LibrarianId { get; set; }
        public User Librarian { get; set; }
    }
}
