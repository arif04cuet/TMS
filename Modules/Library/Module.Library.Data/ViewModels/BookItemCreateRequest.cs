using Module.Library.Entities;
using System;
using System.Collections.Generic;

namespace Module.Library.Data
{
    public class BookItemCreateRequest
    {
        public long Book { get; set; }
        public long? Format { get; set; }
        public long? Status { get; set; }
        public long? Rack { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public float PurchasePrice { get; set; }
        public long? Edition { get; set; }
        public long NumberOfCopy { get; set; }
        public ICollection<BookItemIsbnBarcodeRequest> IsbnAndBarcodes { get; set; }

        public BookItem ToBookItem()
        {
            return new BookItem
            {
                BookId = Book,
                FormatId = Format,
                RackId = Rack,
                StatusId = Status,
                DateOfPurchage = DateOfPurchase,
                EditionId = Edition,
                PurchagePrice = PurchasePrice                
            };
        }
    }
}
