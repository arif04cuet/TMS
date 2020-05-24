using System.Collections.Generic;

namespace Module.Training.Data
{
    public class BuildingCreateRequest
    {
        public string Name { get; set; }
        public long Hostel { get; set; }
        public ICollection<FloorRequest> Floors { get; set; }
    }
}
