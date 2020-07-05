using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(BatchScheduleAllocation), Schema = SchemaConstants.Training)]
    public class BatchScheduleAllocation : BaseEntity
    {
        [Searchable]
        public long BatchScheduleId { get; set; }
        public BatchSchedule BatchSchedule { get; set; }

        [Searchable]
        public long? CourseId { get; set; }
        public Course Course { get; set; }

        public long TraineeId { get; set; }
        public User Trainee { get; set; }

        public DateTime AppliedDate { get; set; }
        public DateTime? AllocationDate { get; set; }

        [Searchable]
        public BatchScheduleAllocationStatus Status { get; set; }

        public long? CertificateId { get; set; }
        public Certificate Certificate { get; set; }
    }

    public enum BatchScheduleAllocationStatus : byte
    {
        Rejected = 1,
        Approved = 2,
        Waiting = 3
    }
}
