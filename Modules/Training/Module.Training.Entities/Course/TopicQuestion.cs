using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(TopicQuestion), Schema = SchemaConstants.Training)]
    public class TopicQuestion : BaseEntity
    {
        public long TopicId { get; set; }
        public Topic Topic { get; set; }

        public long QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
