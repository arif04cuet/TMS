using Module.Training.Entities;

namespace Module.Training.Data
{
    public class TopicCreateRequest
    {
        public string Name { get; set; }
        public string Objectives { get; set; }
        public string Outcomes { get; set; }
        public string CourseMaterials { get; set; }
        public string CourseDetails { get; set; }

        public Topic Map(Topic topic = null)
        {
            var entity = topic ?? new Topic();
            entity.Name = Name;
            entity.CourseDetails = CourseDetails;
            entity.CourseMaterials = CourseMaterials;
            entity.Objectives = Objectives;
            entity.Outcomes = Outcomes;
            return entity;
        }
    }
}
