using Module.Asset.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Asset.Data
{
    public class DepreciationViewModel : DepreciationResource
    {
        public long Id { get; set; }

        public static Expression<Func<Depreciation, DepreciationViewModel>> Select()
        {
            return x => new DepreciationViewModel
            {
                Id = x.Id,
                Frequency = x.Frequency,
                IsActive = x.IsActive,
                Name = x.Name,
                Term = x.Term
            };
        }
    }
}
