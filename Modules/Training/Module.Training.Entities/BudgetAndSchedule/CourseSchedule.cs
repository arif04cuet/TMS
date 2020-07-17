using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(CourseSchedule), Schema = SchemaConstants.Training)]
    public class CourseSchedule : IdNameEntity
    {

        public CourseSchedule()
        {
            Budgets = new HashSet<Budget>();
        }

        public long CourseId { get; set; }
        public Course Course { get; set; }

        public long? CoordinatorId { get; set; }
        public User Coordinator { get; set; }

        public long? CoCoordinatorId { get; set; }
        public User CoCoordinator { get; set; }

        public long? Staff1Id { get; set; }
        public User Staff1 { get; set; }

        public long? Staff2Id { get; set; }
        public User Staff2 { get; set; }

        public long? Staff3Id { get; set; }
        public User Staff3 { get; set; }

        public int TotalSeat { get; set; }

        public virtual ICollection<Budget> Budgets { get; private set; }
    }
}
