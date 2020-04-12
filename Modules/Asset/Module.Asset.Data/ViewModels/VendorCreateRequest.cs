using Module.Core.Entities;

namespace Module.Asset.Data
{
    public class VendorCreateRequest
    {

        public string VendorName { get; set; }
        public string VendorEmail { get; set; }
        public string AccountManagerName { get; set; }
        public string AccountManagerPhone { get; set; }
        public long Status { get; set; }

    }

}
