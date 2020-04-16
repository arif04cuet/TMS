using Module.Core.Data;

namespace Module.Library.Data
{
    public class LibraryCreateRequest
    {
        public string Name { get; set; }
        public AddressRequest Address { get; set; }
        public long Librarian { get; set; }
    }
}
