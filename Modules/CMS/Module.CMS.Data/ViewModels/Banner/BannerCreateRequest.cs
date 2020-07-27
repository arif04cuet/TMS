using Module.CMS.Entities;

namespace Module.CMS.Data
{
    public class BannerCreateRequest
    {
        public string Name { get; set; }
        public long Media { get; set; }
        public bool IsActive { get; set; }

        public Banner Map(Banner category = null)
        {
            var entity = category ?? new Banner();
            entity.Name = Name;
            entity.IsActive = IsActive;
            entity.MediaId = Media;
            return entity;
        }
    }
}
