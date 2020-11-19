using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(License), Schema = SchemaConstants.Asset)]
    public class License : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public string ProductKey { get; set; }

        public int Seats { get; set; }
        public int? Available { get; set; }

        [Searchable]
        public string OrderNumber { get; set; }

        public string LicenseToName { get; set; }
        public string LicenseToEmail { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Double PurchaseCost { get; set; }
        public DateTime ExpireDate { get; set; }

        public string Note { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public long ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public long LocationId { get; set; }
        public Office Location { get; set; }

        public long? DepreciationId { get; set; }
        public Depreciation Depreciation { get; set; }

        public List<LicenseSeat> LicenseSeats { get; set; }

    }
}