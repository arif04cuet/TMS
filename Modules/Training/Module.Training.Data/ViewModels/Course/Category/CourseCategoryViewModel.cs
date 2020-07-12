using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class CourseCategoryViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static CourseCategoryViewModel Map(Category category)
        {
            return new CourseCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
