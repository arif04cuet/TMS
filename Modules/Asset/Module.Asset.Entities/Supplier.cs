using Infrastructure.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    public class Supplier : BaseEntity
    {
        [Searchable]
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