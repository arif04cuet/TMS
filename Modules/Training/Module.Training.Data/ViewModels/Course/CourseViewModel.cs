using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class CourseViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Category { get; set; }
        public string Objective { get; set; }
        public string Description { get; set; }

        public static CourseViewModel Map(Course course)
        {
            return new CourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Category = IdNameViewModel.Map(course.Category),
                Objective = course.Objective,
                Description = course.Description
            };
        }
    }
}
