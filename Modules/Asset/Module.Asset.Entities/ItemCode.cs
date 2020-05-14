using Infrastructure.Entities;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(ItemCode), Schema = SchemaConstants.Asset)]
    public class ItemCode : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public string Code { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public int? TotalQuantity { get; set; }
        public int? Available { get; set; }
        
        public int MinQuantity { get; set; }

    }
}