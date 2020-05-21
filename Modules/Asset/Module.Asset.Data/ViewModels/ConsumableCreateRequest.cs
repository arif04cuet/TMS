
using Module.Asset.Entities;
using System;

namespace Module.Asset.Data
{
    public class ConsumableCreateRequest
    {
        public long ItemCode { get; set; }
        public long? Manufacturer { get; set; }
        public long? Supplier { get; set; }
        public long? Location { get; set; }
        public string OrderNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double PurchaseCost { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public long? Media { get; set; }

        public Consumable ToMap(Consumable consumable = null)
        {
            var entity = consumable ?? new Consumable();
            entity.ItemCodeId = ItemCode;
            entity.LocationId = Location;
            entity.ManufacturerId = Manufacturer;
            entity.MediaId = Media;
            entity.Note = Note;
            entity.OrderNumber = OrderNumber;
            entity.InvoiceNumber = InvoiceNumber;
            entity.PurchaseCost = PurchaseCost;
            entity.PurchaseDate = PurchaseDate;
            entity.Quantity = Quantity;
            entity.SupplierId = Supplier;
            return entity;
        }

    }
}
