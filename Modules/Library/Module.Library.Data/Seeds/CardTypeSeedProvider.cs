using Infrastructure.Data;
using Module.Library.Entities;
using System.Collections.Generic;

namespace Module.Library.Data
{
    public class CardTypeSeedProvider : ISeedProvider<LibraryCardType>
    {
        public int Order => 0;
        public IEnumerable<LibraryCardType> GetSeeds()
        {
            return new List<LibraryCardType>
            {
                new LibraryCardType(1, "Normal"),
                new LibraryCardType(2, "Premium")
            };
        }
    }
}
