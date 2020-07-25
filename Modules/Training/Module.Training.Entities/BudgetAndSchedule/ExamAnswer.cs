using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(ExamAnswer), Schema = SchemaConstants.Training)]
    public class ExamAnswer : BaseEntity
    {
        public long AllocationId { get; set; }
        public BatchScheduleAllocation Allocation { get; set; }

        public long? QuestionId { get; set; }
        public ExamQuestion Question { get; set; }

        public long? McqAnswerId { get; set; }
        public QuestionOption McqAnswer { get; set; }

        public string WrittenAnswer { get; set; }

    }
}
