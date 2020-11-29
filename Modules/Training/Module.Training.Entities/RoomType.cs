using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(RoomType), Schema = SchemaConstants.Training)]
    [CheckUnique]
    public class RoomType : IdNameEntity
    {
        public float Rent { get; set; }

        public long? DesignationId { get; set; }
        public Designation Designation { get; set; }
    }
}
