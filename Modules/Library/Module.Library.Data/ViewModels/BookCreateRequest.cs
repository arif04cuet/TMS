using Module.Library.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Module.Library.Data
{
    public class BookCreateRequest
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public long Language { get; set; }
        public long? Author { get; set; }
        public long? Publisher { get; set; }
        public long? MediaId { get; set; }

        public IEnumerable<long> Authors { get; set; }
        public IEnumerable<long> Subjects { get; set; }
        public IEnumerable<BookEditionRequest> Editions { get; set; }

        public Book ToBook()
        {
            return new Book
            {
                Title = Title,
                Description = Description,
                Excerpt = Excerpt,
                LanguageId = Language,
                AuthorId = Author,
                PublisherId = Publisher,
                Isbn = Isbn,
                MediaId = MediaId
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

        public IEnumerable<BookSubject> ToBookSubjects(long bookId)
        {
            return Subjects.Select(x => new BookSubject { BookId = bookId, SubjectId = x });
        }

        public IEnumerable<BookEdition> ToBookEditions(long bookId)
        {
            return Editions.Select(x => ToBookEdition(x, bookId));
        }

        public BookEdition ToBookEdition(BookEditionRequest x, long bookId)
        {
            return new BookEdition
            {
                BookId = bookId,
                Edition = x.Edition,
                NumberOfCopy = x.NumberOfCopy,
                NumberOfPage = x.NumberOfPage,
                PublicationDate = x.PublicationDate,
            };
        }
    }
}
