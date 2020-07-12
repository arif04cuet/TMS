using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class CourseListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Category { get; set; }
        public int TotalMark { get; set; }
        public int Duration { get; set; }
        public int TotalModule { get; set; }
        public int TotalEvaluationMethod { get; set; }

        public static Expression<Func<Course, CourseListViewModel>> Select()
        {
            return x => new CourseListViewModel
            {
                Id = x.Id,
                Category = new IdNameViewModel { Id = x.Category.Id, Name = x.Category.Name },
                Name = x.Name,
                TotalMark = x.TotalMark,
                Duration = x.Duration,
                TotalModule = x.Modules.Select(y => y.Id).Count(),
                TotalEvaluationMethod =- x.EvaluationMethods.Select(y => y.Id).Count()
            };
        }
    }
}
