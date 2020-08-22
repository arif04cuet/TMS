using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Asset.Data
{
    public class AssetDashboardViewModel : IViewModel
    {
        public IEnumerable<AssetReorderAlertViewModel> ReorderAlert { get; set; }
        public AssetCurrentStockViewModel CurrentStock { get; set; }
        public long Requisition { get; set; }
        public long AssetReturnAlert { get; set; }
        public long BatchWiseItemRequiredAndReceived { get; set; }
    }

    public class AssetReorderAlertViewModel : IViewModel
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Item { get; set; }
        public long Quantity { get; set; }
        public long Available { get; set; }
        public long MinQuantity { get; set; }
    }

    public class AssetCurrentStockViewModel : IViewModel
    {
        public long Asset { get; set; }
        public long License { get; set; }
        public long Consumable { get; set; }
    }
}
