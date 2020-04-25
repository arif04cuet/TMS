using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(EmailTemplate), Schema = SchemaConstants.Core)]
    public class EmailTemplate : BaseEntity
    {
        public string Title { get; set; }
        public string Template { get; set; }
        public EmailTemplateEvent Event { get; set; }
    }
}
