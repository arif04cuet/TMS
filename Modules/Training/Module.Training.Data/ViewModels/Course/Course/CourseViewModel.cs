using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.IO;

namespace Module.Training.Data
{
    public class CourseViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Category { get; set; }
        public string Objective { get; set; }
        public string Description { get; set; }

        public long Image { get; set; }
        public string ImageUrl { get; set; }
        public int TotalMark { get; set; }
        public int Duration { get; set; }
        public IEnumerable<IdNameViewModel> Methods { get; set; }
        public IEnumerable<CourseCourseModuleViewModel> Modules { get; set; }
        public IEnumerable<CourseEvaluationMethodViewModel> EvaluationMethods { get; set; }

        public static Expression<Func<Course, CourseViewModel>> Select()
        {
            return x => new CourseViewModel
            {
                Id = x.Id,
                Category = new IdNameViewModel { Id = x.Category.Id, Name = x.Category.Name },
                Description = x.Description,
                Objective = x.Objective,
                Name = x.Name,
                TotalMark = x.TotalMark,
                Duration = x.Duration,
                Image = x.ImageId.HasValue ? x.Image.Id : 0,
                ImageUrl = x.ImageId.HasValue ? Path.Combine(MediaConstants.Path, x.Image.FileName) : string.Empty,
                Modules = x.Modules.Select(y => new CourseCourseModuleViewModel
                {
                    Id = y.Id,
                    CourseModule = new IdNameViewModel { Id = y.CourseModuleId, Name = y.CourseModule.Name },
                    Duration = y.Duration,
                    Marks = y.Marks
                }),
                Methods = x.Methods.Select(y => new IdNameViewModel { Id = y.MethodId, Name = y.Method.Name }),
                EvaluationMethods = x.EvaluationMethods.Select(y => new CourseEvaluationMethodViewModel
                {
                    Id = y.Id,
                    EvaluationMethod = new IdNameViewModel { Id = y.EvaluationMethodId, Name = y.EvaluationMethod.Name },
                    Mark = y.Mark
                })
            };
        }
    }
}
