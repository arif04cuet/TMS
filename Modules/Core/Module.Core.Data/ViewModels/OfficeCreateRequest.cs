using Module.Core.Entities;
using Module.Core.Shared;

namespace Module.Core.Data
{
    public class OfficeCreateRequest : IViewModel
    {
        public string OfficeName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public long? District { get; set; }
        public long? Upazila { get; set; }
        public long? Division { get; set; }

        public Office MapTo(Office office)
        {
            if (office != null)
            {
                office.AddressLine1 = AddressLine1;
                office.AddressLine2 = AddressLine2;
                office.DistrictId = District;
                office.UpazilaId = Upazila;
                office.DivisionId = Division;
                office.OfficeName = OfficeName;
            }
            return office;
        }

        public Office ToAddress()
        {
            var address = new Office
            {
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                DistrictId = District,
                UpazilaId = Upazila,
                DivisionId = Division,
                OfficeName = OfficeName
            };
            return address;
        }

    }
}
