using Module.Core.Shared;

namespace Module.Training.Data
{
    public class HotelAndRoomViewModel : IViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int BedCount { get; set; }
        public string ImageUrl { get; set; }
    }
}
