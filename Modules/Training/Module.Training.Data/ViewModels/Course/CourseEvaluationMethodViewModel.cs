using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class CourseEvaluationMethodViewModel : IViewModel
    {
        public long? Id { get; set; }
        public IdNameViewModel EvaluationMethod { get; set; }
        public int Mark { get; set; }

        public static Expression<Func<CourseEvaluationMethod, CourseEvaluationMethodViewModel>> Select()
        {
            return x => new CourseEvaluationMethodViewModel
            {
                Id = x.Id,
                EvaluationMethod = new IdNameViewModel
                {
                    Id = x.EvaluationMethodId,
                    Name = x.EvaluationMethod.Name
                },
                Mark = x.Mark
            };
        }

    }
}
