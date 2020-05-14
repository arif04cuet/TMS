
using System;

namespace Module.Asset.Data
{
    public class AssetCheckoutRequest
    {
        public long AssetId { get; set; }
        public long? ChekoutToUserId { get; set; }
        public long? ChekoutToLocationId { get; set; }
        public long? ChekoutToAssetId { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public DateTime? ExpectedChekinDate { get; set; }
        public string Note { get; set; }
    }
}
