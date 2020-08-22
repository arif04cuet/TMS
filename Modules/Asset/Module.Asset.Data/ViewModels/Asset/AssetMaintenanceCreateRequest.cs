using Module.Asset.Entities;
using System;

namespace Module.Asset.Data
{
    public class AssetMaintenanceCreateRequest
    {
        public string Title { get; set; }
        public MaintenanceType Type { get; set; }
        public long Asset { get; set; }
        public long Supplier { get; set; }
        public bool IsWarrantyImprovement { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public double Cost { get; set; }
        public string Note { get; set; }

        public AssetMaintenance ToMap(AssetMaintenance entity = null)
        {
            var _entity = entity ?? new AssetMaintenance();
            _entity.Title = Title;
            _entity.Type = Type;
            _entity.AssetId = Asset;
            _entity.SupplierId = Supplier;
            _entity.IsWarrantyImprovement = IsWarrantyImprovement;
            _entity.StartDate = StartDate;
            _entity.CompletionDate = CompletionDate;
            _entity.Cost = Cost;
            _entity.Note = Note;
            return _entity;
        }
    }
}
