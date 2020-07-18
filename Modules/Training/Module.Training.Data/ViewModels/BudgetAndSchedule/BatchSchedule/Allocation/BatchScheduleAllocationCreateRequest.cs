using Module.Training.Entities;
using System;

namespace Module.Training.Data
{
    public class BatchScheduleAllocationCreateRequest
    {
        public long BatchSchedule { get; set; }
        public long Course { get; set; }
        // UserId
        public long Trainee { get; set; }
        public DateTime AppliedDate { get; set; }

        public BatchScheduleAllocationStatus Status { get; set; }

        public BatchScheduleAllocation Map(BatchScheduleAllocation allocation = null)
        {
            var entity = allocation ?? new BatchScheduleAllocation();
            entity.BatchScheduleId = BatchSchedule;
            entity.CourseId = Course;
            entity.TraineeId = Trainee;
            entity.AppliedDate = AppliedDate;
            entity.Status = Status;
            return entity;
        }
    }
}
