using Module.Core.Shared;

namespace Module.Library.Data
{
    public class LibraryCountViewModel : IViewModel
    {
        public int LibraryCount { get; set; }
        public int BookategoryCount { get; set; }
        public int BookCount { get; set; }
    }
}
