using Module.Core.Shared;
using System;

namespace Module.Asset.Data
{
    public class ConsumableCheckoutViewModel : IViewModel
    {
        public long Id { get; set; }
        public long ConsumableId { get; set; }
        public IdNameViewModel User { get; set; }
        public AssetItemCodeViewModel Item { get; set; }
        public AssetCategoryViewModel Category { get; set; }
        public int Quantity { get; set; }
        public DateTime? IssueDate { get; set; }
    }
}
