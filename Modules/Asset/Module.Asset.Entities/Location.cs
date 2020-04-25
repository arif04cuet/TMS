using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Asset.Entities
{
    [Table(nameof(Location), Schema = SchemaConstants.Asset)]
    public class Location : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public string Address { get; set; }
    }
}