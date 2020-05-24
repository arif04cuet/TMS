using System.Collections.Generic;

namespace Module.Training.Data
{
    public class RoomCreateRequest
    {

        public string Name { get; set; }
        public long RoomType { get; set; }
        public long Building { get; set; }
        public long Hostel { get; set; }
        public long Floor { get; set; }
        public ICollection<BedRequest> Beds { get; set; }
        public long?[] Facilities { get; set; }
    }
}
