using System;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    public class ConsumableUser : BaseEntity
    {


        public long ConsumableId { get; set; }
        public Consumable Consumable { get; set; }

        public long? IssuedToUserId { get; set; }
        public virtual User IssuedToUser { get; set; }

        public DateTime? IssueDate { get; set; }

        public string Note { get; set; }

    }
}