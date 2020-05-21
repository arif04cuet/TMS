using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Building), Schema = SchemaConstants.Training)]
    public class Building : IdNameEntity
    {
        public long HostelId { get; set; }
        public Hostel Hostel { get; set; }
    }
}
