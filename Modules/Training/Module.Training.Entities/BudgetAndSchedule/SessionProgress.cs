using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(SessionProgress), Schema = SchemaConstants.Training)]
    public class SessionProgress : BaseEntity
    {
        public long BatchScheduleId { get; set; }
        public BatchSchedule BatchSchedule { get; set; }

        public long TopicId { get; set; }
        public Topic Topic { get; set; }

        public long CourseModuleId { get; set; }
        public CourseModule CourseModule { get; set; }

        public bool Completed { get; set; }
        public bool SheetGenerated { get; set; }

    }

}
