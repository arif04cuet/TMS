using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Module.Asset.Entities
{
    public enum MasterCategory
    {
        Asset = 1,
        //Accessory = 2,
        Consumable = 2,
        //Component = 4,
        License = 3
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

        /*
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public List<Category> Children { get; set; }
        */

    }
}