using Module.Asset.Entities;
using Module.Core.Shared;
using System;
using System.Linq.Expressions;

namespace Module.Asset.Data
{
    public class RequisitionHistoryItemViewModel
    {
        public long Id { get; set; }
        public long? RequisitionId { get; set; }
        public long RequisitionHistoryId { get; set; }
        public long? RequisitionItemId { get; set; }
        public IdNameViewModel Asset { get; set; }
        public IdNameViewModel AssetType { get; set; }
        public int RequestQuantity { get; set; }
        public int? ChangedQuantity { get; set; }
        public string Comment { get; set; }

        public static Expression<Func<RequisitionHistoryItem, RequisitionHistoryItemViewModel>> Select()
        {
            return x => new RequisitionHistoryItemViewModel
            {
                Id = x.Id,
                RequisitionId = x.RequisitionId,
                RequisitionHistoryId = x.RequisitionHistoryId,
                Asset = new IdNameViewModel { Id = x.AssetId },
                AssetType = new IdNameViewModel { Id = (long)x.AssetType, Name = x.AssetType.ToString() },
                RequestQuantity = x.Quantity,
                Comment = x.Comment
            };
        }

    }
}
