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
        public DateTime? AllocationDate { get; set; }

        public long? Bed { get; set; }
        public long? Room { get; set; }

        public BatchScheduleAllocationStatus Status { get; set; }

        public BatchScheduleAllocation Map(BatchScheduleAllocation allocation = null)
        {
            var entity = allocation ?? new BatchScheduleAllocation();
            entity.BatchScheduleId = BatchSchedule;
            entity.CourseId = Course;
            entity.TraineeId = Trainee;
            entity.AppliedDate = AppliedDate;
            entity.AllocationDate = AllocationDate;
            entity.Status = Status;
            entity.BedId = Bed;
            entity.RoomId = Room;
            return entity;
        }
    }
}
