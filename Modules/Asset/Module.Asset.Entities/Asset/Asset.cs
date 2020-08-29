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
        [Searchable]
        public string AssetTag { get; set; }

        public long AssetModelId { get; set; }
        public AssetModel AssetModel { get; set; }
        [Searchable]
        public long StatusId { get; set; }
        [Searchable]
        public AssetStatus Status { get; set; }

        public string ItemNo { get; set; }

        [Searchable]
        public string Name { get; set; }

        public DateTime? InventoryEntryDate { get; set; }

        public double PurchaseCost { get; set; }
        public DateTime? PurchaseDate { get; set; }

        [Searchable]
        public long? SupplierId { get; set; }
        [Searchable]
        public Supplier Supplier { get; set; }

        public string OrderNo { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }

        public int Warranty { get; set; }
        public int Maintenance { get; set; }

        public string Note { get; set; }

        public bool IsRequestable { get; set; }

        public long? LocationId { get; set; }
        public Office Location { get; set; }

        public int EOL { get; set; }
        public bool HasDepreciated { get; set; }
        public DateTime? NextDepreciateDate { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }

        [Searchable]
        public long? CheckoutId { get; set; }
        [ForeignKey(nameof(CheckoutId))]
        [Searchable]
        public AssetCheckout Checkout { get; set; }

    }
}