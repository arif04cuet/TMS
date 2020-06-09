using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class CourseViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Category { get; set; }
        public string Objective { get; set; }
        public string Description { get; set; }

        public int TotalMark { get; set; }
        public IEnumerable<IdNameViewModel> Methods { get; set; }
        public IEnumerable<IdNameViewModel> Modules { get; set; }
        public IEnumerable<IdNameViewModel> EvaluationMethods { get; set; }

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
                Modules = x.Modules.Select(y => new IdNameViewModel { Id = y.CourseModuleId, Name = y.CourseModule.Name }),
                Methods = x.Methods.Select(y => new IdNameViewModel { Id = y.MethodId, Name = y.Method.Name }),
                EvaluationMethods = x.EvaluationMethods.Select(y => new IdNameViewModel { Id = y.EvaluationMethodId, Name = y.EvaluationMethod.Name })
            };
        }
    }
}
