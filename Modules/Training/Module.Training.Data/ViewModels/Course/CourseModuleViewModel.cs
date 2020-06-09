using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class CourseModuleViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int Marks { get; set; }
        public string Objectives { get; set; }
        public IdNameViewModel Director { get; set; }
        public IEnumerable<IdNameViewModel> Topics { get; set; }

        public static Expression<Func<CourseModule, CourseModuleViewModel>> Select()
        {
            return x => new CourseModuleViewModel
            {
                Director = x.DirectorId != null ? new IdNameViewModel { Id = x.Director.Id, Name = x.Director.FullName } : null,
                Duration = x.Duration,
                Name = x.Name,
                Marks = x.Marks,
                Objectives = x.Objectives,
                Id = x.Id
            };
        }
    }
}
