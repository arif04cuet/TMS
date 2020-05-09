
using System;

namespace Module.Asset.Data
{
    public class AssetCheckoutRequest
    {
        public long AssetId { get; set; }
        public long? CheckoutToUserId { get; set; }
        public long? CheckoutToLocationId { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public DateTime? ExpectedChekinDate { get; set; }
        public string Note { get; set; }
    }
}
