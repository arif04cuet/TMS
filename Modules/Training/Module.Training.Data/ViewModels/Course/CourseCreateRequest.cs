using Module.Training.Entities;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class CourseCreateRequest
    {
        public string Name { get; set; }
        public long Category { get; set; }
        public string Objective { get; set; }
        public string Description { get; set; }

        public int TotalMark { get; set; }
        public long[] Methods { get; set; }
        public long[] Modules { get; set; }
        public IEnumerable<CourseEvaluationMethodRequest> EvaluationMethods { get; set; }

        public Course Map(Course course = null)
        {
            var entity = course ?? new Course();
            entity.Name = Name;
            entity.CategoryId = Category;
            entity.Objective = Objective;
            entity.Description = Description;
            entity.TotalMark = TotalMark;
            return entity;
        }
    }
}
