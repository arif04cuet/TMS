using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class TopicListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Objectives { get; set; }
        public int Duration { get; set; }
        public int Marks { get; set; }

        public static Expression<Func<Topic, TopicListViewModel>> Select()
        {
            return x => new TopicListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Objectives = x.Objectives,
                Duration = x.Duration,
                Marks = x.Marks
            };
        }
    }
}
