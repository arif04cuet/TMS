using Module.Core.Shared;

namespace Module.Training.Data
{
    public class CourseEvaluationMethodRequest
    {
        public long? Id { get; set; }
        public IdNameViewModel EvaluationMethod { get; set; }
        public int Mark { get; set; }
    }
}
