using Infrastructure.Entities;

namespace Module.Library.Entities
{
    public class Rack : IdNameEntity
    {
        public int FloorNo { get; set; }
        public string BuildingName { get; set; }

    }
}
