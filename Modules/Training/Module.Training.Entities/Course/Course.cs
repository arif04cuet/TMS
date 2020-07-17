using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities;

namespace Module.Training.Entities
{
    [Table(nameof(Course), Schema = SchemaConstants.Training)]
    public class Course : IdNameEntity
    {

        public Course()
        {
            Modules = new HashSet<Course_CourseModule>();
            Methods = new HashSet<CourseMethod>();
            EvaluationMethods = new HashSet<CourseEvaluationMethod>();
        }

        public long? ImageId { get; set; }
        public Media Image { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public string Objective { get; set; }
        public string Description { get; set; }

        public int TotalMark { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<Course_CourseModule> Modules { get; private set; }
        public virtual ICollection<CourseMethod> Methods { get; private set; }
        public virtual ICollection<CourseEvaluationMethod> EvaluationMethods { get; private set; }
    }
}
