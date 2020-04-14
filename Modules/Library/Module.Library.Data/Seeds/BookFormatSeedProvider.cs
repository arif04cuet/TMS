using Infrastructure.Data;
using Module.Library.Entities;
using System.Collections.Generic;

using static Module.Library.Data.BookFormatConstants;

namespace Module.Library.Data
{
    public class BookFormatSeedProvider : ISeedProvider<BookFormat>
    {
        public int Order => 0;
        public IEnumerable<BookFormat> GetSeeds()
        {
            return new List<BookFormat>
            {
                new BookFormat(Hardcover, "Hardcover"),
                new BookFormat(Paperback, "Paperback"),
                new BookFormat(Audiobook, "Audiobook"),
                new BookFormat(Ebook, "Ebook"),
                new BookFormat(Newspaper, "Newspaper"),
                new BookFormat(Magazine, "Magazine"),
                new BookFormat(Journal, "Journal")
            };
        }
    }
}
