using Module.Core.Shared;

namespace Module.Library.Data
{
    public class LibraryListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Librarian { get; set; }

    }
}
