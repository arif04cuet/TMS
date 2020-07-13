using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(CourseModule_Course), Schema = SchemaConstants.Training)]
    public class CourseModule_Course : BaseEntity
    {
        public long CourseId { get; set; }
        public Course Course { get; set; }

        public long CourseModuleId { get; set; }
        public CourseModule CourseModule { get; set; }
    }
}
