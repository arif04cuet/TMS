using System;
using Infrastructure.Entities;
using Module.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    [Table(nameof(AccessoryUser), Schema = SchemaConstants.Asset)]
    public class AccessoryUser : BaseEntity
    {
        public long AccessoryId { get; set; }
        public Accessory Accessory { get; set; }

        public long? IssuedToUserId { get; set; }
        [Searchable]
        public virtual User IssuedToUser { get; set; }

        public DateTime? IssueDate { get; set; }

        public string Note { get; set; }

    }
}