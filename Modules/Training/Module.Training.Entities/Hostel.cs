using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Hostel), Schema = SchemaConstants.Training)]
    public class Hostel : IdNameEntity
    {

        public Hostel()
        {
            Floors = new HashSet<Floor>();
            Rooms = new HashSet<Room>();
            Beds = new HashSet<Bed>();
            Allocations = new HashSet<Allocation>();
        }

        public long? AddressId { get; set; }
        public Address Address { get; set; }

        public virtual ICollection<Floor> Floors { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Bed> Beds { get; set; }
        public virtual ICollection<Allocation> Allocations { get; set; }
    }
}
