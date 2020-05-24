using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class BuildingViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Hostel { get; set; }
        public ICollection<IdNameViewModel> Floors { get; set; }
    }
}
