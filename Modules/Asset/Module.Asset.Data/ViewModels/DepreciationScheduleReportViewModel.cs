using Module.Asset.Entities;
using Module.Core.Shared;
using System;
using System.Linq.Expressions;

namespace Module.Asset.Data
{
    public class DepreciationScheduleReportViewModel
    {
        public IdNameViewModel Asset { get; set; }
        public double Price { get; set; }
        public int EOL { get; set; }
        public float CurrentDepreciation { get; set; }
        public float DepreciationRate { get; set; }
        public float DepreciationValue { get; set; }
        public float CurrentValue { get; set; }

        public static Expression<Func<AssetDepreciationSchedule, DepreciationScheduleReportViewModel>> Select()
        {
            return x => new DepreciationScheduleReportViewModel
            {
                Asset = x.AssetId.HasValue ? new IdNameViewModel { Id = x.Asset.Id, Name = x.Asset.Name } : null,
                EOL = x.AssetDepreciationId.HasValue ? x.AssetDepreciation.EOL : 0,
                Price = x.Asset.PurchaseCost,
                CurrentDepreciation = x.CurrentDepreciation,
                CurrentValue = x.CurrentValue,
                DepreciationRate = x.AssetDepreciationId.HasValue ? x.AssetDepreciation.RatePerFrequency : 0,
                DepreciationValue = x.CummulativeValue
            };
        }
    }
}
