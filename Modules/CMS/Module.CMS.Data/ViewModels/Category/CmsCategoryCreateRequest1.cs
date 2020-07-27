using Module.CMS.Entities;

namespace Module.CMS.Data
{
    public class CmsCategoryCreateRequest
    {
        public string Name { get; set; }

        public CmsCategory Map(CmsCategory category = null)
        {
            var entity = category ?? new CmsCategory();
            entity.Name = Name;
            return entity;
        }
    }
}
