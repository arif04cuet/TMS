using Module.Training.Entities;

namespace Module.Training.Data
{
    public class CourseCategoryCreateRequest
    {
        public string Name { get; set; }

        public Category Map(Category category = null)
        {
            var entity = category ?? new Category();
            entity.Name = Name;
            return entity;
        }
    }
}
