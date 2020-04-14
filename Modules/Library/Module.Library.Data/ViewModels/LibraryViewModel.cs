using Module.Core.Data;

namespace Module.Library.Data
{
    public class LibraryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
