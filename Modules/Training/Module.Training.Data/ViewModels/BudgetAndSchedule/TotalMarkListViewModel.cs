using Module.Core.Shared;

namespace Module.Training.Data
{

    public class TotalMarkListViewModel
    {
        public long? Id { get; set; }

        // here participant is BatchScheduleAllocation
        public IdNameViewModel Participant { get; set; }
        public long CourseEvaluationMethodId { get; set; }
        public IdNameViewModel EvaluationMethod { get; set; }
        public int Mark { get; set; }

    }

}
