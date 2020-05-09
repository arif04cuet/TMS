using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Asset.Entities
{
    [Table(nameof(AssetCheckout), Schema = SchemaConstants.Asset)]
    public class AssetCheckout : BaseEntity
    {
        public long AssetId { get; set; }
        public Asset Asset { get; set; }

        public long? ChekoutToUserId { get; set; }
        public User ChekoutToUser { get; set; }

        public long? ChekoutToLocationId { get; set; }
        public Office ChekoutToLocation { get; set; }

        public DateTime? CheckoutDate { get; set; }
        public DateTime? ExpectedChekinDate { get; set; }

    }
}
