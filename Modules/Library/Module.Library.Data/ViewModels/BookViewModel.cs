using Module.Core.Shared;

namespace Module.Library.Data
{
    public class BookViewModel
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public string Isbn { get; set; }
        public float Price { get; set; }
        public string Binding { get; set; }
        public float Weight { get; set; }
        public bool HasEBook { get; set; }

        public IdNameViewModel Language { get; set; }
        public IdNameViewModel BookShelf { get; set; }
        public int RackNumber { get; set; }
        public IdNameViewModel Author { get; set; }
        public IdNameViewModel Publisher { get; set; }

    }
}
