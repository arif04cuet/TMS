using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(Book), Schema = SchemaConstants.Library)]
    public class Book : LibraryEntity
    {
        [Searchable]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        [Searchable]
        public string Isbn { get; set; }

        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }

        [Searchable]
        public long? PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        [Searchable]
        public long? AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public long? MediaId { get; set; }
        public virtual Media Media { get; set; }

    }
}
