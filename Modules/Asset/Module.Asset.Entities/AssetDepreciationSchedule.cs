using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;
using System;

namespace Module.Asset.Entities
{
    [Table(nameof(AssetDepreciationSchedule), Schema = SchemaConstants.Asset)]
    public class AssetDepreciationSchedule : BaseEntity
    {
        public long? AssetId { get; set; }
        public Asset Asset { get; set; }

        public long? AssetDepreciationId { get; set; }
        public AssetDepreciation AssetDepreciation { get; set; }

        public float CurrentDepreciation { get; set; }
        public float CummulativeValue { get; set; }
        public float CurrentValue { get; set; }
    }
}