using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class ExamViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel BatchSchedule { get; set; }
        public IdNameViewModel EvaluationMethod { get; set; }
        public int Mark { get; set; }
        public int TotalMinutes { get; set; }
        public IdNameViewModel Status { get; set; }
        public DateTime ExamDate { get; set; }

        public static Expression<Func<Exam, ExamViewModel>> Select()
        {
            return x => new ExamViewModel
            {
                Id = x.Id,
                BatchSchedule = new IdNameViewModel { Id = x.BatchScheduleId, Name = x.BatchSchedule.CourseSchedule.Name },
                EvaluationMethod = new IdNameViewModel { Id = x.EvaluationMethodId, Name = x.EvaluationMethod.Name },
                Mark = x.Mark,
                ExamDate = x.ExamDate,
                Name = x.Name,
                Status = new IdNameViewModel { Id = (long)x.Status, Name = x.Status.ToString() },
                TotalMinutes = x.TotalMinutes
            };
        }
    }
}
