using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Asset.Entities
{
    [Table(nameof(Manufacturer), Schema = SchemaConstants.Asset)]
    [CheckUnique]
    public class Manufacturer : BaseEntity
    {
        [Searchable]
        [UniqueField]
        public string Name { get; set; }

        [Searchable]
        public string Url { get; set; }

        [Searchable]
        public string SupportUrl { get; set; }

        [Searchable]
        public string SupportPhone { get; set; }

        [Searchable]
        public string SupportEmail { get; set; }


        public long? MediaId { get; set; }
        public Media Media { get; set; }

    }
}