using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(CourseScheduleEligible), Schema = SchemaConstants.Training)]
    public class CourseScheduleEligible : BaseEntity
    {
        public long CourseScheduleId { get; set; }
        public CourseSchedule CourseSchedule { get; set; }

        public long DesignationId { get; set; }
        public Designation Designation { get; set; }
    }
}
