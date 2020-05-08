using System;
using Module.Asset.Entities;

namespace Module.Asset.Data
{
    public class AccessoryRequest
    {
        public string Name { get; set; }
        public long Category { get; set; }
        public long? Manufacturer { get; set; }
        public long? Supplier { get; set; }
        public long? Location { get; set; }
        public string ModelNo { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public double? PurchaseCost { get; set; }
        public int Quantity { get; set; }
        public int? MinQuantity { get; set; }
        public string Note { get; set; }

        public Accessory ToMap(Accessory accessory = null)
        {
            var entity = accessory ?? new Accessory();
            entity.Name = Name;
            entity.ModelNo = ModelNo;
            entity.OrderNumber = OrderNumber;
            entity.PurchaseDate = PurchaseDate;
            entity.PurchaseCost = PurchaseCost;
            entity.Note = Note;
            entity.Quantity = Quantity;
            entity.MinQuantity = MinQuantity;
            entity.CategoryId = Category;
            entity.ManufacturerId = Manufacturer;
            entity.SupplierId = Supplier;
            entity.LocationId = Location;
            return entity;
        }

    }

}


