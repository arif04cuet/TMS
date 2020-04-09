using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

using static Module.Core.Data.ReligionConstants;

namespace Module.Core.Data.Seeds
{
    public class ReligionSeedProvider : ISeedProvider<Religion>
    {
        public int Order => 0;

        public IEnumerable<Religion> GetSeeds()
        {
            return new List<Religion>
            {
                new Religion(Islam, "Islam"),
                new Religion(Judaism, "Judaism"),
                new Religion(Hinduism, "Hinduism"),
                new Religion(Christianity, "Christianity"),
                new Religion(Buddhism, "Buddhism"),
                new Religion(Jainism, "Jainism"),
                new Religion(Sikhism, "Sikhism"),
                new Religion(Other, "Other")
            };
        }
    }
}
