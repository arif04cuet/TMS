using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(CourseSchedule), Schema = SchemaConstants.Training)]
    public class CourseSchedule : IdNameEntity
    {
        public long CourseId { get; set; }
        public Course Course { get; set; }

        public long? CoordinatorId { get; set; }
        public User Coordinator { get; set; }

        public long? CoCoordinatorId { get; set; }
        public User CoCoordinator { get; set; }

        public int TotalSeat { get; set; }
    }
}
