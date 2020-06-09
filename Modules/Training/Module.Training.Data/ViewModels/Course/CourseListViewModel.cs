using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class CourseListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Category { get; set; }
        public int TotalMark { get; set; }

        public static Expression<Func<Course, CourseListViewModel>> Select()
        {
            return x => new CourseListViewModel
            {
                Id = x.Id,
                Category = new IdNameViewModel { Id = x.Category.Id, Name = x.Category.Name },
                Name = x.Name,
                TotalMark = x.TotalMark
            };
        }
    }
}
