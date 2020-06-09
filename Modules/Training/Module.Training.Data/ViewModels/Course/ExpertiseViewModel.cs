using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class ExpertiseViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Expertise, ExpertiseViewModel>> Select()
        {
            return x => new ExpertiseViewModel
            {
                Id = x.Id,
                Name = x.Name
            };
        }
    }
}
