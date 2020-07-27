using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.CMS.Entities
{
    [Table(nameof(Banner), Schema = SchemaConstants.Cms)]
    public class Banner : BaseEntity
    {
        public string Name { get; set; }
        public long MediaId { get; set; }
        public Media Media { get; set; }


    }
}
