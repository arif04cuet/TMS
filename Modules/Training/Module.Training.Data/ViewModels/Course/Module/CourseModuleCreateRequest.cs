using Module.Training.Entities;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class CourseModuleCreateRequest
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public int Marks { get; set; }
        public string Objectives { get; set; }
        public long Director { get; set; }

        public IEnumerable<CourseModuleTopicRequest> Topics { get; set; }

        public CourseModule Map(CourseModule courseModel = null)
        {
            var entity = courseModel ?? new CourseModule();
            entity.Name = Name;
            entity.Duration = Duration;
            entity.Marks = Marks;
            entity.Objectives = Objectives;
            entity.DirectorId = Director;
            return entity;
        }
    }
}
