using Infrastructure.Entities;
using System;

namespace Module.Library.Entities
{
    public class BookEdition : BaseEntity
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public long? EBookId { get; set; }
        public EBook EBook { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool HasEBook { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfCopy { get; set; }
        public float PurchagePrice { get; set; }
        public float RentalPrice { get; set; }
        public string Edition { get; set; }

    }
}
