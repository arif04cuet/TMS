using Module.Asset.Entities;

namespace Module.Asset.Data
{
    public class StatusResource
    {
        public string Name { get; set; }
        public MasterStatus Type { get; set; }
        public string Color { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }

    }
}