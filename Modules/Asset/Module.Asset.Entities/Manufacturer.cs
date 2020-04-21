using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    public class Manufacturer : BaseEntity
    {
        [Searchable]
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