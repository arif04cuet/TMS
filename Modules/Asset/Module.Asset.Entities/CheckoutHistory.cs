using System;
using Infrastructure.Entities;
using Module.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(CheckoutHistory), Schema = SchemaConstants.Asset)]
    public class CheckoutHistory : IEntity
    {

        public long Id { get; set; }

        public long? ActionById { get; set; }
        public virtual User ActionBy { get; set; }

        // Could be Users, Assests, Accessories, Components or Consumables
        public long? TargetId { get; set; }
        public AssetType TargetType { get; set; }

        // Could be Users, Assests, Accessories, Components or Consumables
        public long? ItemId { get; set; }
        public AssetType ItemType { get; set; }

        public AssetAction Action { get; set; }

        public DateTime? IssueDate { get; set; }
        public string Note { get; set; }

    }
}