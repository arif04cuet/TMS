using Module.Library.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Module.Library.Data
{
    public class BookCreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public string Isbn { get; set; }
        public string Binding { get; set; }
        public long Language { get; set; }
        public long? Author { get; set; }
        public long? Publisher { get; set; }

        public IEnumerable<long> Authors { get; set; }
        public IEnumerable<long> Subjects { get; set; }
        public IEnumerable<BookItemRequest> BookItems { get; set; }

        public Book ToBook()
        {
            return new Book
            {
                Title = Title,
                Description = Description,
                Excerpt = Excerpt,
                Isbn = Isbn,
                Binding = Binding,
                LanguageId = Language,
                AuthorId = Author,
                PublisherId = Publisher,
            };
        }
        public IEnumerable<BookAuthor> ToBookAuthors(long bookId)
        {
            return Authors.Select(x => new BookAuthor
            {
                AuthorId = x,
                BookId = bookId
            });
        }

        public IEnumerable<BookItem> ToBookItems(long bookId)
        {
            return BookItems.Select(x =>
            {
                var item = x.ToBookItem();
                item.BookId = bookId;
                return item;
            });
        }

        public IEnumerable<BookSubject> ToBookSubjects(long bookId)
        {
            return Subjects.Select(x => new BookSubject { BookId = bookId, SubjectId = x });
        }
    }
}
