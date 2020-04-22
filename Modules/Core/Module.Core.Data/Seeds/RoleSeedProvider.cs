using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;

using static Module.Core.Data.RoleConstants;

namespace Module.Core.Data
{
    public class RoleSeedProvider : ISeedProvider<Role>
    {
        public int Order => 0;
        public IEnumerable<Role> GetSeeds()
        {
            return new List<Role>
            {
                new Role(Administrator, "Administrator"),
                new Role(Librarian, "Librarian"),
                new Role(LibraryMember, "Library Member")
            };
        }
    }
}
