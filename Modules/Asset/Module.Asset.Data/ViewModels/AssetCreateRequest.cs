using System;

namespace Module.Asset.Data
{
    public class AssetCreateRequest
    {

        public string AssetTag { get; set; }
        public long AssetModel { get; set; }
        public long Status { get; set; }
        public string ItemNo { get; set; }
        public string Name { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public long? Supplier { get; set; }
        public string OrderNo { get; set; }
        public double PurchaseCost { get; set; }
        public int Warranty { get; set; }
        public string Note { get; set; }
        public bool IsRequestable { get; set; }
        public long? Location { get; set; }
        public long? Media { get; set; }

        public Entities.Asset ToMap(Entities.Asset asset = null)
        {
            var entity = asset ?? new Entities.Asset();
            entity.AssetModelId = AssetModel;
            entity.AssetTag = AssetTag;
            entity.IsRequestable = IsRequestable;
            entity.ItemNo = ItemNo;
            entity.LocationId = Location;
            entity.MediaId = Media;
            entity.Name = Name;
            entity.Note = Note;
            entity.OrderNo = OrderNo;
            entity.PurchaseCost = PurchaseCost;
            entity.PurchaseDate = PurchaseDate;
            entity.StatusId = Status;
            entity.SupplierId = Supplier;
            entity.Warranty = Warranty;
            return entity;
        }
    }
}
