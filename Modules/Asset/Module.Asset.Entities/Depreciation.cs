using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Asset.Entities
{
    [Table(nameof(Depreciation), Schema = SchemaConstants.Asset)]
    public class Depreciation : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public int Term { get; set; }
        public int Frequency { get; set; }
    }
}