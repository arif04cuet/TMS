using Module.Asset.Entities;
using Module.Core.Shared;
using System;

namespace Module.Asset.Data
{
    public class CheckoutHistoryListViewModel
    {
        public long Id { get; set; }
        public long TargetId { get; set; }
        public string TargetName { get; set; }
        public AssetType TargetType { get; set; }
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public AssetType ItemType { get; set; }
        public AssetAction Action { get; set; }
        public string Note { get; set; }
        public DateTime? IssueDate { get; set; }
    }
}
