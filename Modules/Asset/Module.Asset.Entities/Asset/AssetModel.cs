using System.Collections.Generic;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(AssetModel), Schema = SchemaConstants.Asset)]
    [CheckUnique]
    public class AssetModel : BaseEntity
    {
        [Searchable]
        [UniqueField]
        public string Name { get; set; }

        [Searchable]
        public string ModelNo { get; set; }

        public string Note { get; set; }
        [Searchable]
        public long CategoryId { get; set; }
        [Searchable]
        public Category Category { get; set; }

        public long? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public bool IsRequestable { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }

        public List<Asset> Assets { get; set; }

    }
}