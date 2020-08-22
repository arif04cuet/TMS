using Module.Core.Shared;
using System;

namespace Module.Asset.Data
{
    public class AssetMaintenanceViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public IdNameViewModel Type { get; set; }
        public IdNameViewModel Asset { get; set; }
        public IdNameViewModel Supplier { get; set; }
        public bool IsWarrantyImprovement { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public double Cost { get; set; }
        public string Note { get; set; }
    }
}
