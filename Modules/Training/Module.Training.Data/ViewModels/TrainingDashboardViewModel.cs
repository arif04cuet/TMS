using Module.Core.Shared;

namespace Module.Training.Data
{
    public class TrainingDashboardViewModel : IViewModel
    {
        public long RunningCourses { get; set; }
        public long RunningBatches { get; set; }
        public long TotalParticipants { get; set; }
        public long TodaysClasses { get; set; }
        public long TodaysExams { get; set; }
        public long TodaysResourcesPersons { get; set; }
    }
}
