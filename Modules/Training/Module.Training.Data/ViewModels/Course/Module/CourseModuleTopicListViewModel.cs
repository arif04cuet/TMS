using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class CourseModuleTopicListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Marks { get; set; }
        public int ResourcePersonCount { get; set; }

        public static Expression<Func<CourseModuleTopic, CourseModuleTopicListViewModel>> Select()
        {
            return x => new CourseModuleTopicListViewModel
            {
                Id = x.TopicId,
                Duration = x.Duration,
                Marks = x.Marks,
                Name = x.Topic.Name,
                ResourcePersonCount = x.Topic.ResoursePersons.Select(y => y.Id).Count()
            };
        }
    }
}
