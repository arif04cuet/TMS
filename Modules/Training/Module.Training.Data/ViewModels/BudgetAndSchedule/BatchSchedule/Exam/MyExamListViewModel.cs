using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class MyExamListViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel BatchSchedule { get; set; }
        public IdNameViewModel CourseSchedule { get; set; }
        public IdNameViewModel Course { get; set; }

        public static Expression<Func<Exam, MyExamListViewModel>> Select()
        {
            return x => new MyExamListViewModel
            {
                Id = x.Id,
                BatchSchedule = new IdNameViewModel { Id = x.BatchScheduleId, Name = x.BatchSchedule.CourseSchedule.Name },
                CourseSchedule = new IdNameViewModel { Id = x.BatchSchedule.CourseScheduleId, Name = x.BatchSchedule.CourseSchedule.Name },
                Course = new IdNameViewModel { Id = x.BatchSchedule.CourseSchedule.Course.Id, Name = x.BatchSchedule.CourseSchedule.Course.Name },
            };
        }
    }
}
