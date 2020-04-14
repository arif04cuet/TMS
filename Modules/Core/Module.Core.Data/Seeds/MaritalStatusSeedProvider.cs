using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

using static Module.Core.Data.MaritalStatusConstants;

namespace Module.Core.Data.Seeds
{
    public class MaritalStatusSeedProvider : ISeedProvider<MaritalStatus>
    {
        public int Order => 0;

        public IEnumerable<MaritalStatus> GetSeeds()
        {
            return new List<MaritalStatus> {
                new MaritalStatus(Married, "Married"),
                new MaritalStatus(UnMarried, "Un married"),
                new MaritalStatus(Widowed, "Widowed"),
                new MaritalStatus(Divorced, "Divorced"),
                new MaritalStatus(NeverMarried, "Never married")
            };
        }
    }
}
