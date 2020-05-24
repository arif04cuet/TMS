using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Floor), Schema = SchemaConstants.Training)]
    public class Floor : IdNameEntity
    {
        public Floor()
        {
            Rooms = new HashSet<Room>();
            Beds = new HashSet<Bed>();
            Allocations = new HashSet<Allocation>();
        }

        public long BuildingId { get; set; }
        public Building Building { get; set; }

        public long HostelId { get; set; }
        public virtual Hostel Hostel { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Bed> Beds { get; set; }
        public virtual ICollection<Allocation> Allocations { get; set; }
    }
}
