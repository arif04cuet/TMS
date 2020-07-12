using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class TopicListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Marks { get; set; }

        public static TopicListViewModel Map(Topic topic)
        {
            return new TopicListViewModel
            {
                Id = topic.Id,
                Name = topic.Name,
                Duration = topic.Duration,
                Marks = topic.Marks
            };
        }
    }
}
