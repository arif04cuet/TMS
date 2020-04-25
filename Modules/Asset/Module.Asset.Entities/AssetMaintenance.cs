using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{

    public enum MaintenanceType
    {
        Maintenance = 1,
        Repair = 2,
        Upgrade = 3,
        Software_Support = 4,
        Hardware_Support = 5,
        Others = 6
    }


    public class AssetMaintenance : BaseEntity
    {
        [Searchable]
        public string Title { get; set; }


        [Searchable]
        public MaintenanceType Type { get; set; }

        public long? AssetId { get; set; }
        public virtual AssetModel Asset { get; set; }

        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public bool IsWarrantyImprovement { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public Double Cost { get; set; }
        public string Note { get; set; }


    }
}