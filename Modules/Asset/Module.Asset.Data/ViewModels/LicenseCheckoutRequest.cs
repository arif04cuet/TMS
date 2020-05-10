using System;
using System.Collections.Generic;
using Module.Asset.Entities;

namespace Module.Asset.Data
{
    public class LicenseCheckoutRequest
    {
        public long Id { get; set; }
        public long LicenseSeatId { get; set; }
        public long? IssuedToUserId { get; set; }
        public long? IssuedToAssetId { get; set; }
        public string Note { get; set; }
    }

}


