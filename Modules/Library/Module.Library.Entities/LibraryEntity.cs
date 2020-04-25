using Infrastructure.Entities;
using Msi.UtilityKit.Search;

namespace Module.Library.Entities
{
    [IgnoredEntity]
    public class LibraryEntity : BaseEntity
    {
        [Searchable]
        public long? LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
