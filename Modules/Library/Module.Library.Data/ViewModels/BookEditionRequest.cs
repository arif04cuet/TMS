using Module.Library.Entities;
using System;

namespace Module.Library.Data
{
    public class BookEditionRequest
    {
        public DateTime PublicationDate { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfCopy { get; set; }
        public float PurchagePrice { get; set; }
        public float RentalPrice { get; set; }
        public string Edition { get; set; }

        public BookEdition ToBookBookEdition(long bookId, long? ebookId = default)
        {
            return new BookEdition
            {
                BookId = bookId,
                EBookId = ebookId,
                Edition = Edition,
                NumberOfCopy = NumberOfCopy,
                NumberOfPage = NumberOfPage,
                PublicationDate = PublicationDate,
                RentalPrice = RentalPrice,
                PurchagePrice = PurchagePrice
            };
        }
    }
}
