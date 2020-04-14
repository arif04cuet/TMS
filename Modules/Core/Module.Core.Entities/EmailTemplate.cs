using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class EmailTemplate : BaseEntity
    {
        public string Title { get; set; }
        public string Template { get; set; }
        public EmailTemplateEvent Event { get; set; }
    }
}
