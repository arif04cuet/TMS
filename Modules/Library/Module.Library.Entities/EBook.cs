using Infrastructure.Entities;
using Module.Core.Entities;

namespace Module.Library.Entities
{
    public class EBook : BaseEntity
    {
        public long MediaId { get; set; }
        public Media Media { get; set; }
        public bool IsDownloadable { get; set; }

        public long? FormatId { get; set; }
        public EBookFormat Format { get; set; }

    }
}
