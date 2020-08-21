using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Building), Schema = SchemaConstants.Training)]
    public class Building : IdNameEntity
    {
        [Searchable]
        public long HostelId { get; set; }
        public Hostel Hostel { get; set; }
    }
}
