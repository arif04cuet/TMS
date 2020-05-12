using System;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(Asset), Schema = SchemaConstants.Asset)]
    public class Asset : BaseEntity
    {

        [Searchable]
        public string Barcode { get; set; }

        public long AssetModelId { get; set; }
        public AssetModel AssetModel { get; set; }

        public long StatusId { get; set; }
        public AssetStatus Status { get; set; }

        public string ItemNo { get; set; }

        [Searchable]
        public string Name { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public long? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public string OrderNo { get; set; }

        public double PurchaseCost { get; set; }

        public int Warranty { get; set; }

        public string Note { get; set; }

        public bool IsRequestable { get; set; }

        public long? LocationId { get; set; }
        public Office Location { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }

    }
}