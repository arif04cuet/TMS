using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Room), Schema = SchemaConstants.Training)]
    public class Room : IdNameEntity
    {
        public long TypeId { get; set; }
        public RoomType Type { get; set; }

        public long BuildingId { get; set; }
        public Building Building { get; set; }

        public long FloorId { get; set; }
        public Floor Floor { get; set; }

        public long HostelId { get; set; }
        public Hostel Hostel { get; set; }

        public bool IsBooked { get; set; }
    }
}
