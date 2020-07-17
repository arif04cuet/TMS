using Module.Training.Entities;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class CourseScheduleCreateRequest
    {
        public string Name { get; set; }
        public long Course { get; set; }
        public long? Coordinator { get; set; }
        public long? CoCoordinator { get; set; }
        public long? Staff1 { get; set; }
        public long? Staff2 { get; set; }
        public long? Staff3 { get; set; }
        public int TotalSeat { get; set; }
        public IEnumerable<long> EligibleFor { get; set; }
        public IEnumerable<BudgetRequest> Budgets { get; set; }

        public CourseSchedule Map(CourseSchedule courseSchedule = null)
        {
            var entity = courseSchedule ?? new CourseSchedule();
            entity.Name = Name;
            entity.CourseId = Course;
            entity.CoordinatorId = Coordinator;
            entity.CoCoordinatorId = CoCoordinator;
            entity.Staff1Id = Staff1;
            entity.Staff2Id = Staff2;
            entity.Staff3Id = Staff3;
            entity.TotalSeat = TotalSeat;
            return entity;
        }
    }
}
