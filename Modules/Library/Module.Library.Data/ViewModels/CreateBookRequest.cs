using Module.Library.Entities;

namespace Module.Library.ViewModels
{
    public class BookCreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public string Isbn { get; set; }
        public float Price { get; set; }
        public string Binding { get; set; }
        public float Weight { get; set; }
        public bool HasEBook { get; set; }
        public long LanguageId { get; set; }
        public long BookShelfId { get; set; }
        public int RackNumber { get; set; }
        public long AuthorId { get; set; }
        public long PublisherId { get; set; }

        public Book ToBook()
        {
            return new Book
            {
                Binding = Binding,
                BookShelfId = BookShelfId,
                Description = Description,
                Excerpt = Excerpt,
                HasEBook = HasEBook,
                Isbn = Isbn,
                LanguageId = LanguageId,
                Price = Price,
                PublisherId = PublisherId,
                RackNumber = RackNumber,
                Title = Title,
                Weight = Weight
            };
        }
    }
}
