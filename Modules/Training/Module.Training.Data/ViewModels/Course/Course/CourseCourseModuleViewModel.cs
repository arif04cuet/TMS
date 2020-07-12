using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class CourseCourseModuleViewModel : IViewModel
    {
        public long? Id { get; set; }
        public IdNameViewModel CourseModule { get; set; }
        public int Marks { get; set; }
        public int Duration { get; set; }

        public static Expression<Func<Course_CourseModule, CourseCourseModuleViewModel>> Select()
        {
            return x => new CourseCourseModuleViewModel
            {
                Id = x.Id,
                CourseModule = new IdNameViewModel
                {
                    Id = x.CourseModuleId,
                    Name = x.CourseModule.Name
                },
                Marks = x.Marks,
                Duration = x.Duration
            };
        }

    }
}
