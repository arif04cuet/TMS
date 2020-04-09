using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class UserRoleSeedProvider : ISeedProvider<UserRole>
    {
        public int Order => 1;
        public IEnumerable<UserRole> GetSeeds()
        {
            return new List<UserRole>
            {
                new UserRole {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1
                }
            };
        }
    }
}
