using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{

    [Table(nameof(AssetAudit), Schema = SchemaConstants.Asset)]
    public class AssetAudit : BaseEntity
    {

        public long? AssetId { get; set; }
        public virtual AssetModel Asset { get; set; }

        public DateTime AuditDate { get; set; }
        public DateTime NextAuditDate { get; set; }

        public string Note { get; set; }


    }
}