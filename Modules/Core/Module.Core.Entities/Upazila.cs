using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Upazila : IdNameEntity
    {

        public long DivisionId { get; set; }
        public Division Division { get; set; }

        public long DistrictId { get; set; }
        public District District { get; set; }

        public Upazila()
        {

        }

        public Upazila(long id, string name)
        {
        }
    }
}
