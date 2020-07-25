using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class RoomViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Type { get; set; }
        public IdNameViewModel Building { get; set; }
        public IdNameViewModel Floor { get; set; }
        public IdNameViewModel Hostel { get; set; }
        public ICollection<IdNameViewModel> Facilities { get; set; }
        public ICollection<IdNameViewModel> Beds { get; set; }
        public long Image { get; set; }
        public string ImageUrl { get; set; }
        public bool IsBooked { get; set; }
    }
}
