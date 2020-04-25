using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(Media), Schema = SchemaConstants.Core)]
    public class Media : BaseEntity
    {
        public string Title { get; set; }
        public long Size { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public bool IsInUse { get; set; }
    }
}
