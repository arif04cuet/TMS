using Module.Core.Entities;
using Module.Core.Shared;

namespace Module.Core.Data
{
    public class OfficeViewModel : IViewModel
    {
        public long Id { get; set; }
        public string OfficeName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public IdNameViewModel Division { get; set; }
        public IdNameViewModel District { get; set; }
        public IdNameViewModel Upazila { get; set; }

        public static OfficeViewModel Map(Office office)
        {
            if (office != null)
            {
                return new OfficeViewModel
                {
                    AddressLine1 = office.AddressLine1,
                    AddressLine2 = office.AddressLine2,
                    OfficeName = office.OfficeName,
                    Division = IdNameViewModel.Map(office.Division),
                    District = IdNameViewModel.Map(office.District),
                    Upazila = IdNameViewModel.Map(office.Upazila)
                };
            }
            return default;
        }
    }
}
