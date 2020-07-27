using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Module.CMS.Entities
{
    [Table(nameof(Content), Schema = SchemaConstants.Cms)]
    public class Content : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        public string Summery { get; set; }
        public string Body { get; set; }

        public long? ImageId { get; set; }
        public Media Image { get; set; }

        public long? AttachmentId { get; set; }
        public Media Attachment { get; set; }

        public long CategoryId { get; set; }
        [Searchable]
        public Category Category { get; set; }

    }
}