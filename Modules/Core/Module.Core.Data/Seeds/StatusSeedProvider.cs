using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

using static Module.Core.Data.StatusConstants;

namespace Module.Core.Data
{
    public class StatusSeedProvider : ISeedProvider<Status>
    {
        public int Order => 0;
        public IEnumerable<Status> GetSeeds()
        {
            return new List<Status>
            {
                new Status(Pending, "Pending"),
                new Status(Approved, "Approved"),
                new Status(Active, "Active"),
                new Status(InActive, "InActive")
            };
        }
    }
}
