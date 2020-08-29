using Module.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module.Asset.Data
{
    public class AssetCreateRequest
    {
        public string Name { get; set; }
        public string OrderNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? InventoryEntryDate { get; set; }
        public long? Supplier { get; set; }
        public string Note { get; set; }
        public long? Location { get; set; }
        public IEnumerable<AssetItemCreateRequest> Items { get; set; }

        public IEnumerable<Entities.Asset> ToMap(IBarcodeService barcodeService)
        {
            return Items.Select(x => new Entities.Asset
            {
                AssetModelId = x.AssetModel,
                AssetTag = x.AssetTag,
                IsRequestable = x.IsRequestable,
                ItemNo = x.ItemNo,
                LocationId = Location,
                MediaId = x.Media,
                Name = Name,
                Note = Note,
                OrderNo = OrderNo,
                InvoiceNo = InvoiceNo,
                PurchaseCost = x.PurchaseCost,
                PurchaseDate = PurchaseDate,
                StatusId = x.Status,
                SupplierId = Supplier,
                Warranty = x.Warranty,
                Maintenance = x.Maintenance,
                EOL = x.Eol,
                Barcode = barcodeService.Generate(),
                InventoryEntryDate = InventoryEntryDate,
                InvoiceDate = InvoiceDate
            });
        }
    }
}
