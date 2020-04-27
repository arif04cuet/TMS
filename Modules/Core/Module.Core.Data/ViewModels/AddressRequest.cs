using Module.Core.Entities;

namespace Module.Core.Data
{
    public class AddressRequest
    {
        public string ContactName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public long? District { get; set; }
        public long? Upazila { get; set; }
        public long? Division { get; set; }

        public Address MapTo(Address address)
        {
            if (address != null)
            {
                address.AddressLine1 = AddressLine1;
                address.AddressLine2 = AddressLine2;
                address.DistrictId = District;
                address.UpazilaId = Upazila;
                address.DivisionId = Division;
                address.ContactName = ContactName;
            }
            return address;
        }

        public Address ToAddress()
        {
            var address = new Address
            {
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                DistrictId = District,
                UpazilaId = Upazila,
                DivisionId = Division,
                ContactName = ContactName
            };
            return address;
        }

    }
}
