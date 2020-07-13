using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class CourseModuleListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Marks { get; set; }
        public IdNameViewModel Director { get; set; }
        public int TotalTopics { get; set; }
        public string Objectives { get; set; }

        public static Expression<Func<CourseModule, CourseModuleListViewModel>> Select()
        {
            return x => new CourseModuleListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Director = x.DirectorId.HasValue ? new IdNameViewModel { Id = x.Director.Id, Name = x.Director.FullName } : null,
                Duration = x.Duration,
                Marks = x.Marks,
                TotalTopics = x.Topics.Select(y => y.Id).Count(),
                Objectives = x.Objectives
            };
        }
    }
}
