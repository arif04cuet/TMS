using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

using static Module.Core.Data.GenderConstants;

namespace Module.Core.Data
{
    public class GenderSeedProvider : ISeedProvider<Gender>
    {
        public int Order => 0;
        public IEnumerable<Gender> GetSeeds()
        {
            return new List<Gender>
            {
                new Gender(Male, "Male"),
                new Gender(Female, "Female"),
                new Gender(Other, "Other")
            };
        }
    }
}
