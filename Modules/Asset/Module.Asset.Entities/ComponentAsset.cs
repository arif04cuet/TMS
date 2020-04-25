using System;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    public class ComponentAsset : BaseEntity
    {


        public long ComponentId { get; set; }
        public Component Component { get; set; }

        public long? IssuedToAssetId { get; set; }
        public virtual AssetModel IssuedToAsset { get; set; }

        public int Quantity { get; set; }

        public DateTime? IssueDate { get; set; }

        public string Note { get; set; }

    }
}