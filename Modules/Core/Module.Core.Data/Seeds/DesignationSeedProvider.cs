using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class DesignationSeedProvider : ISeedProvider<Designation>
    {
        public int Order => 0;
        public IEnumerable<Designation> GetSeeds()
        {
            return new List<Designation>
            {
                new Designation(1, "Director General"),
                new Designation(2, "Director"),
                new Designation(3, "Additional Director"),
                new Designation(4, "Deputy Director or Equivalent"),
                new Designation(5, "Assistant Director or Equivalent"),
                new Designation(6, "Social services officer 1st Class Gazetted or Equivalent"),
                new Designation(7, "Social services officer 2nd Class Gazetted or Equivalent"),
                new Designation(8, "Additional Secretary"),
                new Designation(9, "Secretary"),
                new Designation(10, "Joint Secretary"),
                new Designation(11, "Deputy Secretary"),
                new Designation(12, "Honorable Guest Speaker")
            };
        }
    }
}
