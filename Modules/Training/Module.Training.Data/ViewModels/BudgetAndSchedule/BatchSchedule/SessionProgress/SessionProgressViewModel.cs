using Module.Core.Shared;

namespace Module.Training.Data
{

    public class SessionProgressViewModel
    {
        // RoutinePeriodId
        public long Id { get; set; }
        public IdNameViewModel Topic { get; set; }
        public IdNameViewModel CourseModule { get; set; }
        public bool Completed { get; set; }

    }

}
