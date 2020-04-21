using Infrastructure.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    public class Location : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public string Address { get; set; }
    }
}