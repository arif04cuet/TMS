using Infrastructure.Data;
using System.Collections.Generic;
using static Module.Core.Data.ModuleConstants;

namespace Module.Core.Data
{
    public class ModuleSeedProvider : ISeedProvider<Entities.Module>
    {
        public int Order => 0;
        public IEnumerable<Entities.Module> GetSeeds()
        {
            return new List<Entities.Module>
            {
                new Entities.Module(UserManagement, "User Management"),
                new Entities.Module(LibraryManagement, "Library Management"),
            };
        }
    }
}
