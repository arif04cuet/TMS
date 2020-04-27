using Module.Library.Entities;
using System;

namespace Module.Library.Data
{
    public class BookItemUpdateRequest
    {
        public long Id { get; set; }
        public long Book { get; set; }
        public long? Format { get; set; }
        public long? Status { get; set; }
        public long? Rack { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public float PurchasePrice { get; set; }
        public long? Edition { get; set; }
        public long NumberOfCopy { get; set; }

        public void MapTo(BookItem bookItem)
        {
            if(bookItem != null)
            {
                bookItem.BookId = Book;
                bookItem.DateOfPurchage = DateOfPurchase;
                bookItem.EditionId = Edition;
                bookItem.FormatId = Format;
                bookItem.PurchagePrice = PurchasePrice;
                bookItem.RackId = Rack;
                bookItem.StatusId = Status;
            }
        }
    }
}
