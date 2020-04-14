using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class VendorViewModel
    {
        public long Id { get; set; }
        public string VendorName { get; set; }
        public string VendorEmail { get; set; }
        public string AccountManagerName { get; set; }
        public string AccountManagerPhone { get; set; }

        public IdNameViewModel Status { get; set; }

    }
}
