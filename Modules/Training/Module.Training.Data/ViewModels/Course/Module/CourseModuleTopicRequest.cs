using Module.Core.Shared;

namespace Module.Training.Data
{
    public class CourseModuleTopicRequest
    {
        public long? Id { get; set; }
        public IdNameViewModel Topic { get; set; }
        public int Marks { get; set; }
        public int Duration { get; set; }
    }
}
