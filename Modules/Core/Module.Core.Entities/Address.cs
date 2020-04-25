using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Address), Schema = SchemaConstants.Core)]
    public class Address : BaseEntity
    {
        public string ContactName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public long? DistrictId { get; set; }
        public District District { get; set; }

        public long? UpazilaId { get; set; }
        public Upazila Upazila { get; set; }

        public long? DivisionId { get; set; }
        public Division Division { get; set; }
    }
}
