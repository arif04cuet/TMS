using Infrastructure.Data;
using Module.Library.Entities;
using System.Collections.Generic;

using static Module.Library.Data.MemberStatusConstants;

namespace Module.Library.Data
{
    public class MemberStatusSeedProvider : ISeedProvider<MemberStatus>
    {
        public int Order => 0;
        public IEnumerable<MemberStatus> GetSeeds()
        {
            return new List<MemberStatus>
            {
                new MemberStatus(Active, "Active"),
                new MemberStatus(Closed, "Closed"),
                new MemberStatus(Canceled, "Canceled"),
                new MemberStatus(Blacklisted, "Blacklisted"),
                new MemberStatus(None, "None")
            };
        }
    }
}
