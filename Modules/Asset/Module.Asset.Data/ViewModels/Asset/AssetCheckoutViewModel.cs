using Module.Core.Shared;
using System;

namespace Module.Asset.Data
{
    public class AssetCheckoutViewModel
    {
        public IdNameViewModel ChekoutToAsset { get; set; }
        public IdNameViewModel ChekoutToUser { get; set; }
        public long? ChekoutToLocationId { get; set; }
        public IdNameViewModel ChekoutToLocation { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public DateTime? ExpectedChekinDate { get; set; }
    }
}
