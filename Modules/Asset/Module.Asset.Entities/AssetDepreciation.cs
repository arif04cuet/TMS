using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;
using System;

namespace Module.Asset.Entities
{
    [Table(nameof(AssetDepreciation), Schema = SchemaConstants.Asset)]
    public class AssetDepreciation : BaseEntity
    {
        public long? AssetId { get; set; }
        public Asset Asset { get; set; }

        // Per Year
        public int Term { get; set; }

        // Per Month
        public int Frequency { get; set; }

        public float RatePerFrequency { get; set; }
        public float ValuePerFrequency { get; set; }
        public DateTime NextDepreciateDate { get; set; }
    }
}