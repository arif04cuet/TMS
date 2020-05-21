using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Allocation), Schema = SchemaConstants.Training)]
    public class Allocation : IdNameEntity
    {
        public DateTime CheckinDate { get; set; }
        public DateTime? CheckoutDate { get; set; }

        public long? BedId { get; set; }
        public Bed Bed { get; set; }

        public long? RoomId { get; set; }
        public Room Room { get; set; }

        public long? ScheduleId { get; set; }

        public long BuildingId { get; set; }
        public Building Building { get; set; }

        public long FloorId { get; set; }
        public Floor Floor { get; set; }

        public long HostelId { get; set; }
        public Hostel Hostel { get; set; }

        public int Days { get; set; }
        public double Amount { get; set; }
        public bool IsRoom { get; set; }
    }
}
