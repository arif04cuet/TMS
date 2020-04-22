using Module.Core.Shared;
using System;
using System.Collections.Generic;

namespace Module.Library.Data
{
    public class BookItemViewModel
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public string Barcode { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public float PurchasePrice { get; set; }

        public IdNameViewModel Book { get; set; }
        public IdNameViewModel Status { get; set; }
        public IdNameViewModel Rack { get; set; }
        public IdNameViewModel Format { get; set; }
        public IdNameViewModel Language { get; set; }
        public IdNameViewModel Author { get; set; }
        public IdNameViewModel Publisher { get; set; }
        public IEnumerable<IdNameViewModel> Subjects { get; set; }
        public BookEditionViewModel Edition { get; set; }

    }
}
