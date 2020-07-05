using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(TotalMark), Schema = SchemaConstants.Training)]
    public class TotalMark : BaseEntity
    {
        public long BatchScheduleId { get; set; }
        public BatchSchedule BatchSchedule { get; set; }

        public long? EvaluationMethodId { get; set; }
        public CourseEvaluationMethod EvaluationMethod { get; set; }

        public long? ParticipantId { get; set; }
        public BatchScheduleAllocation Participant { get; set; }

        public int Mark { get; set; }

    }

}
