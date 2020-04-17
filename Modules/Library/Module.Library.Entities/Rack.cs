using Infrastructure.Entities;
using Msi.UtilityKit.Search;

namespace Module.Library.Entities
{
    public class Rack : IdNameEntity
    {
        [Searchable]
        public int FloorNo { get; set; }
        [Searchable]
        public string BuildingName { get; set; }

    }
}
