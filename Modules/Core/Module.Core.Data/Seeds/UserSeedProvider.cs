using Infrastructure.Data;
using Module.Core.Entities;
using Msi.UtilityKit.Security;
using System.Collections.Generic;

using static Module.Core.Data.StatusConstants;

namespace Module.Core.Data
{
    public class UserSeedProvider : ISeedProvider<User>
    {
        public int Order => 1;
        public IEnumerable<User> GetSeeds()
        {
            var users = new List<User>
            {
                new User {
                    Id = 1,
                    FullName = "Administrator",
                    StatusId = Active,
                    Email = "admin@gmail.com",
                    Password = "123456".HashPassword()
                }
            };
            return users;
        }
    }
}
