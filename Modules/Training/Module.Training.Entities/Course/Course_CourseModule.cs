using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Course_CourseModule), Schema = SchemaConstants.Training)]
    public class Course_CourseModule : BaseEntity
    {
        public long CourseId { get; set; }
        public Course Course { get; set; }

        public long CourseModuleId { get; set; }
        public CourseModule CourseModule { get; set; }

        public int Marks { get; set; }
        public int Duration { get; set; }
    }
}
