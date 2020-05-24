using Module.Training.Entities;

namespace Module.Training.Data
{
    public class CourseModuleCreateRequest
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Marks { get; set; }
        public string Objectives { get; set; }

        public CourseModule Map(CourseModule grade = null)
        {
            var entity = grade ?? new CourseModule();
            entity.Name = Name;
            entity.Duration = Duration;
            entity.Marks = Marks;
            entity.Objectives = Objectives;
            return entity;
        }
    }
}
