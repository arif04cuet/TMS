using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(RoomFacilities), Schema = SchemaConstants.Training)]
    public class RoomFacilities : IEntity
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public Room Room { get; set; }

        public long FacilitiesId { get; set; }
        public Facilities Facilities { get; set; }
    }
}
