using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Upazila), Schema = SchemaConstants.Core)]
    public class Upazila : IdNameEntity
    {
        public string BnName { get; set; }
        public long? DivisionId { get; set; }
        public Division Division { get; set; }

        public long? DistrictId { get; set; }
        public District District { get; set; }

        public Upazila() : base()
        {

        }

        public Upazila(long id, string name) : base(id, name)
        {
        }

        public Upazila(long id, long? districtId, long? divistionId, string name, string bnName) : base(id, name)
        {
            DistrictId = districtId;
            DivisionId = divistionId;
            BnName = bnName;
        }
    }
}
