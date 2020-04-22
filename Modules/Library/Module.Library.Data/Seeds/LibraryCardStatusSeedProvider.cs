using Infrastructure.Data;
using Module.Library.Entities;
using System.Collections.Generic;

using static Module.Library.Data.LibraryCardStatusConstants;

namespace Module.Library.Data
{
    public class LibraryCardStatusSeedProvider : ISeedProvider<LibraryCardStatus>
    {
        public int Order => 0;
        public IEnumerable<LibraryCardStatus> GetSeeds()
        {
            return new List<LibraryCardStatus>
            {
                new LibraryCardStatus(Active, "Active"),
                new LibraryCardStatus(InActive, "In active"),
                new LibraryCardStatus(Lost, "Lost")
            };
        }
    }
}
