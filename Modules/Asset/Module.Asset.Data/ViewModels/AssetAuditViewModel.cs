using Module.Core.Shared;
using System;

namespace Module.Asset.Data
{
    public class AssetAuditViewModel
    {
        public long Id { get; set; }
        public IdNameViewModel Asset { get; set; }
        public DateTime AuditDate { get; set; }
        public DateTime NextAuditDate { get; set; }
        public string Note { get; set; }
    }
}
