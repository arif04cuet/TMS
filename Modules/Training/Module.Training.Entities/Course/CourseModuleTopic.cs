using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(CourseModuleTopic), Schema = SchemaConstants.Training)]
    public class CourseModuleTopic : BaseEntity
    {
        public long CourseModuleId { get; set; }
        public CourseModule CourseModule { get; set; }

        public long TopicId { get; set; }
        public Topic Topic { get; set; }

        public int Duration { get; set; }
        public int Marks { get; set; }
    }
}
