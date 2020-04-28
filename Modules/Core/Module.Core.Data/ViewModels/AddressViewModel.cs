using Module.Core.Entities;
using Module.Core.Shared;

namespace Module.Core.Data
{
    public class AddressViewModel : IViewModel
    {
        public string ContactName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public IdNameViewModel Division { get; set; }
        public IdNameViewModel District { get; set; }
        public IdNameViewModel Upazila { get; set; }

        public static AddressViewModel Map(Address address)
        {
            if (address != null)
            {
                return new AddressViewModel
                {
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    ContactName = address.ContactName,
                    Division = IdNameViewModel.Map(address.Division),
                    District = IdNameViewModel.Map(address.District),
                    Upazila = IdNameViewModel.Map(address.Upazila)
                };
            }
            return default;
        }
    }
}
