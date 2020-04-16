using Module.Core.Data;
using Module.Core.Shared;

namespace Module.Library.Data
{
    public class LibraryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Librarian { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
