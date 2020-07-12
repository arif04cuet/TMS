using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
        public IdNameViewModel Method { get; set; }
        public IdNameViewModel EvaluationMethod { get; set; }
        public int Duration { get; set; }
        public int Marks { get; set; }
        public IEnumerable<IdNameViewModel> ResourcePersons { get; set; }

        public static Expression<Func<Topic, TopicViewModel>> Select()
        {
            return x => new TopicViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CourseDetails = x.CourseDetails,
                CourseMaterials = x.CourseMaterials,
                Objectives = x.Objectives,
                Outcomes = x.Outcomes,
                Duration = x.Duration,
                Marks = x.Marks,
                Method = x.MethodId.HasValue ? new IdNameViewModel { Id = x.Method.Id, Name = x.Method.Name } : null,
                EvaluationMethod = x.EvaluationMethodId.HasValue ? new IdNameViewModel { Id = x.EvaluationMethod.Id, Name = x.EvaluationMethod.Name } : null,
            };
        }
    }
}
