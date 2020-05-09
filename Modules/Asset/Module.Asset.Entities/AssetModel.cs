using System.Collections.Generic;
using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(AssetModel), Schema = SchemaConstants.Asset)]
    public class AssetModel : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public string ModelNo { get; set; }

        public int Eol { get; set; }

        public string Note { get; set; }

        public long CategoryId { get; set; }
        [Searchable]
        public Category Category { get; set; }

        public long ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public long? DepreciationId { get; set; }
        public Depreciation Depreciation { get; set; }

        public bool IsRequestable { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }

        public List<AssetModel> AssetModels { get; set; }

    }
}