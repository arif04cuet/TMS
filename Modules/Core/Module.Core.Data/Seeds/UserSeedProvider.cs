using Infrastructure.Data;
using Module.Core.Entities;
using Msi.UtilityKit.Security;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class UserSeedProvider : ISeedProvider<User>
    {
        public int Order => 0;
        public IEnumerable<User> GetSeeds()
        {
            var users = new List<User>
            {
                new User {
                    Id = 1,
                    Email = "admin@gmail.com",
                    Password = "123456".HashPassword()
                }
            };
            return users;
        }
    }
}
