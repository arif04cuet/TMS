using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;
using static Module.Core.Shared.PermissionGroupConstants;

namespace Module.Core.Data
{
    public class PermissionGroupSeedProvider : ISeedProvider<PermissionGroup>
    {
        public int Order => 0;
        public IEnumerable<PermissionGroup> GetSeeds()
        {
            return new List<PermissionGroup>
            {
                //user
                new PermissionGroup(UserGroup, "User"),
                new PermissionGroup(RoleGroup, "Role"),
                new PermissionGroup(DesignationGroup, "Designation"),
                new PermissionGroup(DepartmentGroup, "Department"),
                new PermissionGroup(ProfileGroup, "Profile"),
                
                //library
                new PermissionGroup(BookGroup, "Book"),
                new PermissionGroup(LibraryGroup, "Library"),
                new PermissionGroup(LibraryMemberGroup, "Member"),
                new PermissionGroup(LibraryMemberRequestGroup, "Member Request"),
                new PermissionGroup(CardGroup, "Card"),
                new PermissionGroup(BookCatalogGroup, "Catalog"),
                new PermissionGroup(RackGroup, "Rack"),
                new PermissionGroup(AuthorGroup, "Author"),
                new PermissionGroup(PublisherGroup, "Publisher"),
                new PermissionGroup(BookCategoryGroup, "Category"),
                new PermissionGroup(LibraryReportGroup, "Report"),
                
                //asset
                new PermissionGroup(AssetGroup, "Asset"),
                new PermissionGroup(MaintenanceGroup, "Maintenance"),

                //CMS
                new PermissionGroup(ContentCategoryGroup, "Contents Category"),
                new PermissionGroup(ContentsGroup, "Contents"),
                new PermissionGroup(ContentFaqGroup, "Contents Faq"),
                new PermissionGroup(ContentBannerGroup, "Contents Banner"),

            };
        }
    }
}
