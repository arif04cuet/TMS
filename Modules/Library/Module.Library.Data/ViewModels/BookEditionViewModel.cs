using Module.Core.Shared;
using System;

namespace Module.Library.Data
{
    public class BookEditionViewModel : IViewModel
    {
        public IdNameViewModel Book { get; set; }
        public long? EBookId { get; set; }
        public DateTime PublicationDate { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfCopy { get; set; }
        public float PurchagePrice { get; set; }
        public float RentalPrice { get; set; }
        public string Edition { get; set; }
    }
}
