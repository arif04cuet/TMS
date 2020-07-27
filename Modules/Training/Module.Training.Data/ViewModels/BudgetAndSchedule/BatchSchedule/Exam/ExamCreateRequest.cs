using Module.Training.Entities;
using Msi.UtilityKit.Search;
using System;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class ExamCreateRequest
    {
        public string Name { get; set; }
        public long BatchSchedule { get; set; }
        public long EvaluationMethod { get; set; }
        public ExamEvaluationType? EvaluationType { get; set; }
        public QuestionType? QuestionType { get; set; }
        public int Mark { get; set; }
        public int TotalMinutes { get; set; }
        public int ExtraTime { get; set; }
        public ExamStatus Status { get; set; }
        public DateTime ExamDate { get; set; }
        public bool IsOnline { get; set; }

        public IEnumerable<ExamQuestionRequest> Questions { get; set; }

        public Exam Map(Exam exam = default)
        {
            var entity = exam ?? new Exam();
            entity.Name = Name;
            entity.BatchScheduleId = BatchSchedule;
            entity.EvaluationMethodId = EvaluationMethod;
            entity.Mark = Mark;
            entity.TotalMinutes = TotalMinutes;
            entity.Status = Status;
            entity.ExamDate = ExamDate;
            entity.EvaluationType = EvaluationType;
            entity.QuestionType = QuestionType;
            entity.ExtraTime = ExtraTime;
            entity.IsOnline = IsOnline;
            return entity;
        }
    }
}
