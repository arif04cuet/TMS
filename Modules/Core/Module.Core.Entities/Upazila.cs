using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Upazila), Schema = SchemaConstants.Core)]
    public class Upazila : IdNameEntity
    {

        public long? DivisionId { get; set; }
        public Division Division { get; set; }

        public long? DistrictId { get; set; }
        public District District { get; set; }

        public Upazila()
        {

        }

        public Upazila(long id, string name)
        {
        }
    }
}
