using Infrastructure;

namespace Module.Core.Data
{
    public class AddressViewModel
    {
        public string ContactName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public IdNameViewModel District { get; set; }
        public IdNameViewModel Upazila { get; set; }
    }
}
