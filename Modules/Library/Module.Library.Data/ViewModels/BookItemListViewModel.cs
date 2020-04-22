using Module.Core.Shared;

namespace Module.Library.Data
{
    public class BookItemListViewModel
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Barcode { get; set; }
        public IdNameViewModel Author { get; set; }
        public IdNameViewModel Publisher { get; set; }
        public IdNameViewModel IssuedTo { get; set; }
        public IdNameViewModel Status { get; set; }

    }
}
