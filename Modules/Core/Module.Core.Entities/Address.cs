using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Address : BaseEntity
    {
        public string ContactName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public long? DistrictId { get; set; }
        public District District { get; set; }

        public string Upazila { get; set; }
    }
}
