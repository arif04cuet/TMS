using Module.Core.Shared;

namespace Module.Library.Data
{
    public class BookListViewModel
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IdNameViewModel Author { get; set; }
        public IdNameViewModel Publisher { get; set; }

    }
}
