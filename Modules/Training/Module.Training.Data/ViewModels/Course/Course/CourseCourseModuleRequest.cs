using Module.Core.Shared;

namespace Module.Training.Data
{
    public class CourseCourseModuleRequest
    {
        public long? Id { get; set; }
        public IdNameViewModel CourseModule { get; set; }
        public int Marks { get; set; }
        public int Duration { get; set; }
    }
}
