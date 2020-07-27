using Module.Core.Shared;
using Module.CMS.Entities;

namespace Module.CMS.Data
{
    public class CmsCategoryViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static CmsCategoryViewModel Map(CmsCategory category)
        {
            return new CmsCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
