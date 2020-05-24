using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class TopicViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Objectives { get; set; }
        public string Outcomes { get; set; }
        public string CourseMaterials { get; set; }
        public string CourseDetails { get; set; }

        public static TopicViewModel Map(Topic topic)
        {
            return new TopicViewModel
            {
                Id = topic.Id,
                Name = topic.Name,
                CourseDetails = topic.CourseDetails,
                CourseMaterials = topic.CourseMaterials,
                Objectives = topic.Objectives,
                Outcomes = topic.Outcomes
            };
        }
    }
}
