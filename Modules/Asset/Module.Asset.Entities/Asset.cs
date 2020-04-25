using System;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    public class Asset : BaseEntity
    {


        [Searchable]
        public string Barcode { get; set; }

        public long AssetModelId { get; set; }
        public AssetModel AssetModel { get; set; }

        public long StatusId { get; set; }
        public Status Status { get; set; }

        public string ItemNo { get; set; }

        [Searchable]
        public string Name { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public string OrderNo { get; set; }

        public double PurchaseCost { get; set; }

        public int Warrantly { get; set; }

        public string Note { get; set; }

        public bool IsRequestable { get; set; }

        public long LocationId { get; set; }
        public Location Location { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }

    }
}