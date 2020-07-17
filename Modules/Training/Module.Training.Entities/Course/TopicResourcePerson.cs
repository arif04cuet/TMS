using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(TopicResourcePerson), Schema = SchemaConstants.Training)]
    public class TopicResourcePerson : BaseEntity
    {
        public long TopicId { get; set; }
        public Topic Topic { get; set; }

        public long ResourcePersonId { get; set; }
        public ResourcePerson ResourcePerson { get; set; }
    }
}
