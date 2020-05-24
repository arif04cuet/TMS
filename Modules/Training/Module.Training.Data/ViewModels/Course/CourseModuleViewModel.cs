using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class CourseModuleViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Marks { get; set; }
        public string Objectives { get; set; }

        public static CourseModuleViewModel Map(CourseModule module)
        {
            return new CourseModuleViewModel
            {
                Id = module.Id,
                Name = module.Name,
                Duration = module.Duration,
                Marks = module.Marks,
                Objectives = module.Objectives,
            };
        }
    }
}
