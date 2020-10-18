using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Room), Schema = SchemaConstants.Training)]
    public class Room : IdNameEntity
    {
        public Room()
        {
            Beds = new HashSet<Bed>();
        }

        [Searchable]
        public long TypeId { get; set; }
        [Searchable]
        public RoomType Type { get; set; }

        [Searchable]
        public long BuildingId { get; set; }
        [Searchable]
        public Building Building { get; set; }

        [Searchable]
        public long FloorId { get; set; }
        [Searchable]
        public Floor Floor { get; set; }

        [Searchable]
        public long HostelId { get; set; }
        [Searchable]
        public Hostel Hostel { get; set; }

        [Searchable]
        public bool IsBooked { get; set; }
        [Searchable]
        public long? ImageId { get; set; }

        [Searchable]
        public Media Image { get; set; }


        public virtual ICollection<Bed> Beds { get; set; }
    }
}
