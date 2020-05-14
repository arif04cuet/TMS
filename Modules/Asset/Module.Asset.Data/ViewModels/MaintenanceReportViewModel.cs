using System;

namespace Module.Asset.Data
{
    public class MaintenanceReportViewModel
    {
        public string AssetName { get; set; }
        public string Supplier { get; set; }
        public string AssetMaintenanceType { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public long AssetMaintenanceTime { get; set; }
        public string Cost { get; set; }
    }
}
