using Module.Training.Entities;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class TopicCreateRequest
    {
        public string Name { get; set; }
        public string Objectives { get; set; }
        public string Outcomes { get; set; }
        public string CourseMaterials { get; set; }
        public string CourseDetails { get; set; }
        public long? Method { get; set; }
        public long? EvaluationMethod { get; set; }
        public int Duration { get; set; }
        public int Marks { get; set; }

        public IEnumerable<long> ResourcePersons { get; set; }

        public Topic Map(Topic topic = null)
        {
            var entity = topic ?? new Topic();
            entity.Name = Name;
            entity.CourseDetails = CourseDetails;
            entity.CourseMaterials = CourseMaterials;
            entity.Objectives = Objectives;
            entity.Outcomes = Outcomes;
            entity.MethodId = Method;
            entity.EvaluationMethodId = EvaluationMethod;
            entity.Duration = Duration;
            entity.Marks = Marks;
            return entity;
        }
    }
}
