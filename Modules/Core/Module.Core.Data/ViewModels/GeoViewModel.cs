using Module.Core.Entities;
using Module.Core.Shared;

namespace Module.Core.Data
{
    public class GeoViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Parent { get; set; }

    }
}
