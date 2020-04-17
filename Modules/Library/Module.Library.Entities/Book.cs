using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Library.Entities
{
    public class Book : BaseEntity
    {
        [Searchable]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public string Isbn { get; set; }
        public string Binding { get; set; }

        public long LanguageId { get; set; }
        public Language Language { get; set; }

        [Searchable]
        public long? PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        [Searchable]
        public long? AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
