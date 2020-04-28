using Module.Core.Shared;

namespace Module.Core.Data
{
    public class OfficeListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string OfficeName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public IdNameViewModel Division { get; set; }
        public IdNameViewModel District { get; set; }
        public IdNameViewModel Upazila { get; set; }
    }
}