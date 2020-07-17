using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class CourseModuleTopicViewModel : IViewModel
    {
        public long? Id { get; set; }
        public IdNameViewModel Topic { get; set; }
        public int Marks { get; set; }
        public int Duration { get; set; }

        public static Expression<Func<CourseModuleTopic, CourseModuleTopicViewModel>> Select()
        {
            return x => new CourseModuleTopicViewModel
            {
                Id = x.Id,
                Topic = new IdNameViewModel
                {
                    Id = x.TopicId,
                    Name = x.Topic.Name
                },
                Marks = x.Marks,
                Duration = x.Duration
            };
        }

    }
}
