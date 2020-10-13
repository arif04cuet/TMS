using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(EBook), Schema = SchemaConstants.Library)]
    public class EBook : LibraryEntity
    {
        public long MediaId { get; set; }
        public Media Media { get; set; }

        public long? Media2Id { get; set; }
        public Media Media2 { get; set; }
        public bool IsDownloadable { get; set; }

        public long? FormatId { get; set; }
        public EBookFormat Format { get; set; }

    }
}
