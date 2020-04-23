using Module.Library.Entities;
using System;

namespace Module.Library.Data
{
    public class BookEditionRequest
    {
        public long? Id { get; set; }
        public DateTime PublicationDate { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfCopy { get; set; }
        public string Edition { get; set; }
        public long? EBook { get; set; }

        public BookEdition ToBookBookEdition(long bookId)
        {
            return new BookEdition
            {
                BookId = bookId,
                EBookId = EBook,
                Edition = Edition,
                NumberOfCopy = NumberOfCopy,
                NumberOfPage = NumberOfPage,
                PublicationDate = PublicationDate
            };
        }

        public void MapTo(BookEdition bookEdition, long? bookId = default)
        {
            if (bookEdition != null)
            {
                bookEdition.EBookId = EBook;
                bookEdition.Edition = Edition;
                bookEdition.NumberOfPage = NumberOfPage;
                bookEdition.PublicationDate = PublicationDate;
                if(bookId.HasValue)
                {
                    bookId = bookId.Value;
                }
            }
        }
    }
}
