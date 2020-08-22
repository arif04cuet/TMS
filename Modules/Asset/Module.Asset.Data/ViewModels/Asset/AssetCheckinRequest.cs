using System;

namespace Module.Asset.Data
{
    public class AssetCheckinRequest
    {
        public long AssetId { get; set; }
        public string Note { get; set; }
        public long? Status { get; set; }
        public DateTime? CheckinDate { get; set; }
    }
}
