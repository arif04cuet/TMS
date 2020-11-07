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
                new Role(LibraryMember, "Library Member"),
                new Role(InventoryManager, "Inventory Manager"),
                new Role(HostelManager, "Hostel Manager"),
                new Role(CourseDirector, "Course Director"),
                new Role(CourseCoordinator, "Course Coordinator"),
                new Role(Principle, "Principle"),
                new Role(VicePrinciple, "Vice Principle"),
                new Role(Participant, "Participant"),
                new Role(ResourcePerson, "Resource Person")
            };
        }
    }
}
