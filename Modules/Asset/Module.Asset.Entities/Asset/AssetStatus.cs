using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Asset.Entities
{
    public enum MasterStatus
    {
        Deployable = 1,
        Pending = 2,
        Undeployable = 3,
        Archived = 4
    }

    [Table(nameof(AssetStatus), Schema = SchemaConstants.Asset)]
    [CheckUnique]
    public class AssetStatus : BaseEntity
    {
        [Searchable]
        [UniqueField]
        public string Name { get; set; }

        [Searchable]
        public MasterStatus Type { get; set; }

        public string Color { get; set; }
        public string Note { get; set; }


    }
}