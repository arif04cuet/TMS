using Module.CMS.Entities;

namespace Module.CMS.Data
{
    public class ContentCreateRequest
    {
        public string Name { get; set; }
        public string Summery { get; set; }
        public string Body { get; set; }
        public long CategoryId { get; set; }

        public long? Image { get; set; }
        public long? Attachment { get; set; }
        public bool IsActive { get; set; }

        public Content Map(Content category = null)
        {
            var entity = category ?? new Content();
            entity.Name = Name;
            entity.Summery = Summery;
            entity.Body = Body;
            entity.IsActive = IsActive;
            entity.CategoryId = CategoryId;

            return entity;
        }
    }
}
