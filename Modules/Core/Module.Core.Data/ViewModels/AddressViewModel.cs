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
                    Division = address.Division != null ? new IdNameViewModel
                    {
                        Id = address.Division.Id,
                        Name = address.Division.Name
                    } : null,
                    District = address.District != null ? new IdNameViewModel
                    {
                        Id = address.District.Id,
                        Name = address.District.Name
                    } : null,
                    Upazila = address.Upazila != null ? new IdNameViewModel
                    {
                        Id = address.Upazila.Id,
                        Name = address.Upazila.Name
                    } : null
                };
            }
            return default;
        }
    }
}
