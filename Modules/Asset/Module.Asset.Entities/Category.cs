using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Asset.Entities
{
    public enum MasterCategory
    {
        Asset = 1,
        Accessory = 2,
        Consumable = 3,
        Component = 4,
        License = 5
    }

    [Table(nameof(Category), Schema = SchemaConstants.Asset)]
    public class Category : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public MasterCategory Type { get; set; }

        public string EULA { get; set; }
        public bool IsRequireUserConfirmation { get; set; }
        public bool IsSendEmail { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }
    }
}