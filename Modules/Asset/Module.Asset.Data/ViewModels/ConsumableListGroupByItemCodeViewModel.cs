using Module.Core.Shared;
using System;

namespace Module.Asset.Data
{
    public class ConsumableListGroupByItemCodeViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }
        public int Quantity { get; set; }
        public int? Available { get; set; }
        public int? MinQuantity { get; set; }
    }
}
