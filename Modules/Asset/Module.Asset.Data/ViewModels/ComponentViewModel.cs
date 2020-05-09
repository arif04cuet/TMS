using Module.Core.Shared;
using System;

namespace Module.Asset.Data
{
    public class ComponentViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AssetCategoryViewModel Category { get; set; }
        public IdNameViewModel Manufacturer { get; set; }
        public IdNameViewModel Supplier { get; set; }
        public IdNameViewModel Location { get; set; }
        public string ModelNo { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public double? PurchaseCost { get; set; }
        public int Quantity { get; set; }
        public int? Available { get; set; }
        public int? MinQuantity { get; set; }
        public string Note { get; set; }
        public string Photo { get; set; }
    }
}
