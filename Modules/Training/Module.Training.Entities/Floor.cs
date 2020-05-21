using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Floor), Schema = SchemaConstants.Training)]
    public class Floor : IdNameEntity
    {
        public long BuildingId { get; set; }
        public Building Building { get; set; }

        public long HostelId { get; set; }
        public Hostel Hostel { get; set; }
    }
}
