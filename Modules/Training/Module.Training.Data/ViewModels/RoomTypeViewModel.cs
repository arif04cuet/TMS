using Module.Core.Shared;

namespace Module.Training.Data
{
    public class RoomTypeViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Rent { get; set; }
        public IdNameViewModel Designation { get; set; }
    }
}
