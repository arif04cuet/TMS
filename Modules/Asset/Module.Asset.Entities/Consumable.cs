using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(Consumable), Schema = SchemaConstants.Asset)]
    [CheckUnique]
    public class Consumable : BaseEntity
    {
        [Searchable]

        public string Name { get; set; }
        [Searchable]
        public long ItemCodeId { get; set; }
        public ItemCode ItemCode { get; set; }

        public long? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public long? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public long? LocationId { get; set; }
        public Office Location { get; set; }

        [Searchable]
        public string ModelNo { get; set; }

        [Searchable]
        public string OrderNumber { get; set; }

        [Searchable]
        public string InvoiceNumber { get; set; }

        public DateTime PurchaseDate { get; set; }
        public double PurchaseCost { get; set; }

        public int Quantity { get; set; }
        public int? MinQuantity { get; set; }

        public string Note { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }

        public int? Available { get; set; }

        public List<ConsumableUser> ConsumableUsers { get; set; }

    }
}