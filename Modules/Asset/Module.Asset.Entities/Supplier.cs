using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Asset.Entities
{
    [Table(nameof(Supplier), Schema = SchemaConstants.Asset)]
    [CheckUnique]
    public class Supplier : BaseEntity
    {
        [Searchable]
        [UniqueField]
        public string Name { get; set; }

        [Searchable]
        public string Address { get; set; }

        [Searchable]
        public string ContactName { get; set; }

        [Searchable]
        public string ContactEmail { get; set; }

        [Searchable]
        public string ContactPhone { get; set; }

    }
}