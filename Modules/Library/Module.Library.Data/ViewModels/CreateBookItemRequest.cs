using Module.Library.Entities;
using System;

namespace Module.Library.Data
{
    public class BookCreateItemRequest
    {
        public float Price { get; set; }
        public string Barcode { get; set; }
        public long BookId { get; set; }
        public long? Format { get; set; }
        public long? Status { get; set; }
        public long? Rack { get; set; }
        public DateTime? DateOfPurchage { get; set; }

        public BookItem ToBookItem()
        {
            return new BookItem
            {
                Price = Price,
                Barcode = Barcode,
                BookId = BookId,
                FormatId = Format,
                RackId = Rack,
                StatusId = Status,
                DateOfPurchage = DateOfPurchage
            };
        }
    }
}
