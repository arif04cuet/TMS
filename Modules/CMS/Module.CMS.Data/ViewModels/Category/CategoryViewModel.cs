using Module.Core.Shared;
using Module.CMS.Entities;

namespace Module.CMS.Data
{
    public class CategoryViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static CategoryViewModel Map(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
