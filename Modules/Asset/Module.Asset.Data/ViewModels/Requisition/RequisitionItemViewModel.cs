using Module.Asset.Entities;
using Module.Core.Shared;
using System;
using System.Linq.Expressions;

namespace Module.Asset.Data
{
    public class RequisitionItemViewModel
    {
        public long Id { get; set; }
        public long RequisitionId { get; set; }
        public IdNameViewModel Asset { get; set; }
        public IdNameViewModel AssetType { get; set; }
        public int Available { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }

        public static Expression<Func<RequisitionItem, RequisitionItemViewModel>> Select()
        {
            return x => new RequisitionItemViewModel
            {
                Id = x.Id,
                RequisitionId = x.RequisitionId,
                Asset = new IdNameViewModel { Id = x.AssetId },
                AssetType = new IdNameViewModel { Id = (long)x.AssetType, Name = x.AssetType.ToString() },
                Quantity = x.Quantity,
                Comment = x.Comment
            };
        }

    }
}
