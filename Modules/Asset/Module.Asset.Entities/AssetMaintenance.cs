using System;
using Infrastructure.Entities;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

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

    [Table(nameof(AssetMaintenance), Schema = SchemaConstants.Asset)]
    public class AssetMaintenance : BaseEntity
    {
        [Searchable]
        public string Title { get; set; }


        [Searchable]
        public MaintenanceType Type { get; set; }

        public long? AssetId { get; set; }
        public Asset Asset { get; set; }

        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public bool IsWarrantyImprovement { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public double Cost { get; set; }
        public string Note { get; set; }


    }
}