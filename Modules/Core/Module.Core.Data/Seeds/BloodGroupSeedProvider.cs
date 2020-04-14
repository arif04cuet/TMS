using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

using static Module.Core.Data.BloodGroupConstants;

namespace Module.Core.Data
{
    public class BloodGroupSeedProvider : ISeedProvider<BloodGroup>
    {
        public int Order => 0;
        public IEnumerable<BloodGroup> GetSeeds()
        {
            return new List<BloodGroup>
            {
                new BloodGroup(APositive, "A+"),
                new BloodGroup(ANegative, "A-"),
                new BloodGroup(BPositive, "B+"),
                new BloodGroup(BNegative, "B-"),
                new BloodGroup(ABPositive, "AB+"),
                new BloodGroup(ABNegative, "AB-"),
                new BloodGroup(OPositive, "O+"),
                new BloodGroup(ONegative, "O-")
            };
        }
    }
}
