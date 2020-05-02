using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Library.Data
{
    public class BookViewModel
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public string Isbn { get; set; }
        public string Photo { get; set; }

        public IdNameViewModel Language { get; set; }
        public IdNameViewModel Author { get; set; }
        public IdNameViewModel Publisher { get; set; }
        public IEnumerable<IdNameViewModel> Subjects { get; set; }
        public IEnumerable<BookEditionViewModel> Editions { get; set; }

    }
}
