using Module.Core.Shared;

namespace Module.Library.Data
{
    public class RackViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int FloorNo { get; set; }
        public string BuildingName { get; set; }
    }
}
