using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{



    public class AssetAudit : BaseEntity
    {

        public long? AssetId { get; set; }
        public virtual AssetModel Asset { get; set; }

        public DateTime AuditDate { get; set; }
        public DateTime NextAuditDate { get; set; }

        public string Note { get; set; }


    }
}