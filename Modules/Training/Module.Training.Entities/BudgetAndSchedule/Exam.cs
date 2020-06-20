using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Exam), Schema = SchemaConstants.Training)]
    public class Exam : BaseEntity
    {
        public string Name { get; set; }

        public long BatchScheduleId { get; set; }
        public BatchSchedule BatchSchedule { get; set; }

        public long EvaluationMethodId { get; set; }
        public EvaluationMethod EvaluationMethod { get; set; }

        public int Mark { get; set; }
        public int TotalMinutes { get; set; }

        public ExamStatus Status { get; set; }
        public DateTime ExamDate { get; set; }

    }

    public enum ExamStatus : byte
    {
        Completed = 1,
        Pending = 2
    }

}
