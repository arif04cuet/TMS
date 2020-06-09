using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(ResourcePersonExpertise), Schema = SchemaConstants.Training)]
    public class ResourcePersonExpertise : BaseEntity
    {
        public long ResourcePersonId { get; set; }
        public ResourcePerson ResourcePerson { get; set; }

        public long ExpertiseId { get; set; }
        public Expertise Expertise { get; set; }
    }

}
