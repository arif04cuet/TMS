using Infrastructure.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    public class Depreciation : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public int Term { get; set; }
    }
}