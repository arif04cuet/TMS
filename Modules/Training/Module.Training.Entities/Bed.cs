using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Bed), Schema = SchemaConstants.Training)]
    public class Bed : IdNameEntity
    {
        [Searchable]
        public long BuildingId { get; set; }
        [Searchable]
        public Building Building { get; set; }
        
        [Searchable]
        public long FloorId { get; set; }
        [Searchable]
        public Floor Floor { get; set; }

        [Searchable]
        public long RoomId { get; set; }
        [Searchable]
        public Room Room { get; set; }

        [Searchable]
        public long HostelId { get; set; }
        [Searchable]
        public Hostel Hostel { get; set; }

        [Searchable]
        public bool IsBooked { get; set; }
    }
}
