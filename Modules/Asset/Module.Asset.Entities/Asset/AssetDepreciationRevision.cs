using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;
using System;

namespace Module.Asset.Entities
{
    [Table(nameof(AssetDepreciationRevision), Schema = SchemaConstants.Asset)]
    public class AssetDepreciationRevision : BaseEntity
    {
        public long? AssetId { get; set; }
        public Asset Asset { get; set; }

        // Month
        public int EOL { get; set; }

        // Month
        public int Frequency { get; set; }

        public float RatePerFrequency { get; set; }
        public float ValuePerFrequency { get; set; }
    }
}