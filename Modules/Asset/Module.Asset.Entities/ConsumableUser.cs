using System;
using Infrastructure.Entities;
using Module.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(ConsumableUser), Schema = SchemaConstants.Asset)]
    public class ConsumableUser : BaseEntity
    {


        public long ConsumableId { get; set; }
        public Consumable Consumable { get; set; }

        public long? IssuedToUserId { get; set; }
        public virtual User IssuedToUser { get; set; }

        public DateTime? IssueDate { get; set; }
        public int Quantity { get; set; }

        public string Note { get; set; }

    }
}