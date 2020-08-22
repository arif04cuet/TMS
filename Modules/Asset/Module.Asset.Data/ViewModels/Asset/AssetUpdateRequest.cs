using System;

namespace Module.Asset.Data
{
    public class AssetUpdateRequest
    {
        public long Id { get; set; }
        public string OrderNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? InventoryEntryDate { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public long? Supplier { get; set; }
        public string Note { get; set; }
        public long? Location { get; set; }
        public string AssetTag { get; set; }
        public long AssetModel { get; set; }
        public long Status { get; set; }
        public string ItemNo { get; set; }
        public string Name { get; set; }
        public double PurchaseCost { get; set; }
        public int Warranty { get; set; }
        public int Maintenance { get; set; }
        public long Depreciation { get; set; }
        public bool IsRequestable { get; set; }
        public long? Media { get; set; }

        public Entities.Asset ToMap(Entities.Asset asset = null)
        {
            var entity = asset ?? new Entities.Asset();
            asset.AssetModelId = AssetModel;
            asset.AssetTag = AssetTag;
            asset.IsRequestable = IsRequestable;
            asset.ItemNo = ItemNo;
            asset.LocationId = Location;
            asset.Name = Name;
            asset.Note = Note;
            asset.OrderNo = OrderNo;
            asset.InvoiceNo = InvoiceNo;
            asset.PurchaseCost = PurchaseCost;
            asset.PurchaseDate = PurchaseDate;
            asset.StatusId = Status;
            asset.SupplierId = Supplier;
            asset.Warranty = Warranty;
            asset.Maintenance = Maintenance;
            asset.DepreciationId = Depreciation;
            asset.InventoryEntryDate = InventoryEntryDate;
            asset.InvoiceDate = InvoiceDate;
            if (asset != null && Media.HasValue)
            {
                // update
                asset.MediaId = Media;
            }
            return entity;
        }
    }
}
