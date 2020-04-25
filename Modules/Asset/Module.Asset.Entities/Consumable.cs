using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    public class Consumable : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public long ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public long LocationId { get; set; }
        public Location Location { get; set; }

        [Searchable]
        public string ModelNo { get; set; }

        [Searchable]
        public string OrderNumber { get; set; }

        public DateTime PurchaseDate { get; set; }
        public Double PurchaseCost { get; set; }

        public int Quantity { get; set; }
        public int? MinQuantity { get; set; }

        public string Note { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }

        public List<ConsumableUser> ConsumableUsers { get; set; }

    }
}