using Infrastructure.Data;
using Module.Library.Entities;
using System.Collections.Generic;

using static Module.Library.Data.BookStatusConstants;

namespace Module.Library.Data
{
    public class BookStatusSeedProvider : ISeedProvider<BookStatus>
    {
        public int Order => 0;
        public IEnumerable<BookStatus> GetSeeds()
        {
            return new List<BookStatus>
            {
                new BookStatus(Available, "Available"),
                new BookStatus(Reserved, "Reserved"),
                new BookStatus(Loned, "Loned"),
                new BookStatus(Lost, "Lost")
            };
        }
    }
}
