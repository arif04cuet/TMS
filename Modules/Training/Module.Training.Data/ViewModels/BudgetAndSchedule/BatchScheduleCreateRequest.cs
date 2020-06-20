using Module.Training.Entities;
using System;

namespace Module.Training.Data
{
    public class BatchScheduleCreateRequest
    {
        public long CourseSchedule { get; set; }
        public long? Coordinator { get; set; }
        public long? CoCoordinator { get; set; }
        public int TotalSeat { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }

        public BatchSchedule Map(BatchSchedule batchSchedule = null)
        {
            var entity = batchSchedule ?? new BatchSchedule();
            entity.CourseScheduleId = CourseSchedule;
            entity.CoordinatorId = Coordinator;
            entity.CoCoordinatorId = CoCoordinator;
            entity.TotalSeat = TotalSeat;
            entity.StartDate = StartDate;
            entity.EndDate = EndDate;
            entity.RegistrationStartDate = RegistrationStartDate;
            entity.RegistrationEndDate = RegistrationEndDate;
            return entity;
        }
    }
}
