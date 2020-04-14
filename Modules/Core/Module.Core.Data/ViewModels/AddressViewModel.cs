using Module.Core.Shared;

namespace Module.Core.Data
{
    public class AddressViewModel : IViewModel
    {
        public string ContactName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public IdNameViewModel District { get; set; }
        public string Upazila { get; set; }
    }
}
