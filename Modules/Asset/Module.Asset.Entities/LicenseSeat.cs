using System;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(LicenseSeat), Schema = SchemaConstants.Asset)]
    public class LicenseSeat : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        public long LicenseId { get; set; }
        public License License { get; set; }

        public long? IssuedToUserId { get; set; }
        public virtual User IssuedToUser { get; set; }

        public long? IssuedToAssetId { get; set; }

        public virtual Asset IssuedToAsset { get; set; }

        public DateTime? IssueDate { get; set; }

        public string Note { get; set; }

    }
}