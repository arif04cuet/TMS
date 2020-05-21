using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Bed), Schema = SchemaConstants.Training)]
    public class Bed : IdNameEntity
    {
        public long BuildingId { get; set; }
        public Building Building { get; set; }

        public long FloorId { get; set; }
        public Floor Floor { get; set; }

        public long RoomId { get; set; }
        public Room Room { get; set; }

        public long HostelId { get; set; }
        public Hostel Hostel { get; set; }

        public bool IsBooked { get; set; }
    }
}
