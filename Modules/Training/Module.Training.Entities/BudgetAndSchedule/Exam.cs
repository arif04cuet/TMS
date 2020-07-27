using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Exam), Schema = SchemaConstants.Training)]
    public class Exam : BaseEntity
    {

        public Exam()
        {
            Questions = new HashSet<ExamQuestion>();
        }

        [Searchable]
        public string Name { get; set; }

        public long BatchScheduleId { get; set; }
        public BatchSchedule BatchSchedule { get; set; }

        public long EvaluationMethodId { get; set; }
        public EvaluationMethod EvaluationMethod { get; set; }

        public ExamEvaluationType? EvaluationType { get; set; }
        public QuestionType? QuestionType { get; set; }

        public int Mark { get; set; }
        public int TotalMinutes { get; set; }
        public int ExtraTime { get; set; }

        public bool IsOnline { get; set; }

        public ExamStatus Status { get; set; }
        [Searchable]
        public DateTime ExamDate { get; set; }

        public virtual ICollection<ExamQuestion> Questions { get; private set; }

    }

    public enum ExamStatus : byte
    {
        Completed = 1,
        Pending = 2
    }

    public enum ExamEvaluationType : byte
    {
        PreTraining = 1,
        InTraining = 2,
        PostTraining = 3
    }

}
