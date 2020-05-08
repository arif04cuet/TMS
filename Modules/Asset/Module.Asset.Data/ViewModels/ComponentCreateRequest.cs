
using Module.Asset.Entities;
using System;

namespace Module.Asset.Data
{
    public class ComponentCreateRequest
    {
        public string Name { get; set; }
        public long Category { get; set; }
        public long? Manufacturer { get; set; }
        public long? Supplier { get; set; }
        public long? Location { get; set; }
        public string ModelNo { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public double PurchaseCost { get; set; }
        public int Quantity { get; set; }
        public int? Available { get; set; }
        public int? MinQuantity { get; set; }
        public string Note { get; set; }
        public long? Media { get; set; }

        public Component ToMap(Component component = null)
        {
            var entity = component ?? new Component();
            entity.CategoryId = Category;
            entity.LocationId = Location;
            entity.ManufacturerId = Manufacturer;
            entity.MediaId = Media;
            entity.MinQuantity = MinQuantity;
            entity.ModelNo = ModelNo;
            entity.Name = Name;
            entity.Note = Note;
            entity.OrderNumber = OrderNumber;
            entity.PurchaseCost = PurchaseCost;
            entity.PurchaseDate = PurchaseDate;
            entity.Quantity = Quantity;
            entity.SupplierId = Supplier;
            return entity;
        }
    }
}
