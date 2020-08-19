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
                new Entities.Module(AssetManagement, "Asset Management"),
                new Entities.Module(HostelManagement, "Hostel Management"),
                new Entities.Module(TrainingManagement, "Training Management"),
                new Entities.Module(CmsManagement, "Contents Management"),

            };
        }
    }
}
