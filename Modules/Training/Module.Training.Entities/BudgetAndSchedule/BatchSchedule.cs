using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(BatchSchedule), Schema = SchemaConstants.Training)]
    public class BatchSchedule : BaseEntity
    {
        public long CourseScheduleId { get; set; }
        [Searchable]
        public CourseSchedule CourseSchedule { get; set; }

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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
    }
}
