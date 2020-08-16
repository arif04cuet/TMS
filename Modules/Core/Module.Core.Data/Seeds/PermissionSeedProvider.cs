using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;
using static Module.Core.Shared.PermissionConstants;
using static Module.Core.Shared.PermissionGroupConstants;
using static Module.Core.Shared.PermissionOperationConstants;
using static Module.Core.Data.ModuleConstants;

namespace Module.Core.Data
{
    public class PermissionSeedProvider : ISeedProvider<Permission>
    {
        public int Order => 1;
        public IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>
            {
                #region User
                new Permission (UserCreate, Create, $"user.{Create.ToLower()}", UserGroup, UserManagement),
                new Permission (UserUpdate,  Update, $"user.{Update.ToLower()}", UserGroup, UserManagement),
                new Permission (UserView, View, $"user.{View.ToLower()}", UserGroup, UserManagement),
                new Permission (UserList, List, $"user.{List.ToLower()}", UserGroup, UserManagement),
                new Permission ( UserDelete,  Delete, $"user.{Delete.ToLower()}", UserGroup, UserManagement),
                new Permission (UserManage,  Manage, $"user.{Manage.ToLower()}", UserGroup, UserManagement),
                #endregion

                #region Role
                new Permission {
                    Id = RoleCreate,
                    Name = Create,
                    Code = $"role.{Create.ToLower()}",
                    GroupId = RoleGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = RoleUpdate,
                    Name = Update,
                    Code = $"role.{Update.ToLower()}",
                    GroupId = RoleGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = RoleList,
                    Name = "List",
                    Code = $"role.{List.ToLower()}",
                    GroupId = RoleGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = RoleDelete,
                    Name = Delete,
                    Code = $"role.{Delete.ToLower()}",
                    GroupId = RoleGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = RoleManage,
                    Name = Manage,
                    Code = $"role.{Manage.ToLower()}",
                    GroupId = RoleGroup,
                    ModuleId = UserManagement
                },
                #endregion

                #region Designation
                new Permission {
                    Id = DesignationCreate,
                    Name = Create,
                    Code = $"designation.{Create.ToLower()}",
                    GroupId = DesignationGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = DesignationUpdate,
                    Name = Update,
                    Code = $"designation.{Update.ToLower()}",
                    GroupId = DesignationGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = DesignationList,
                    Name = List,
                    Code = $"designation.{List.ToLower()}",
                    GroupId = DesignationGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = DesignationDelete,
                    Name = Delete,
                    Code = $"designation.{Delete.ToLower()}",
                    GroupId = DesignationGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = DesignationManage,
                    Name = Manage,
                    Code = $"designation.{Manage.ToLower()}",
                    GroupId = DesignationGroup,
                    ModuleId = UserManagement
                },
                #endregion

                #region Department
                new Permission {
                    Id = DepartmentCreate,
                    Name = Create,
                    Code = $"department.{Create.ToLower()}",
                    GroupId = DepartmentGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = DepartmentUpdate,
                    Name = Update,
                    Code = $"department.{Update.ToLower()}",
                    GroupId = DepartmentGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = DepartmentList,
                    Name = List,
                    Code = $"department.{List.ToLower()}",
                    GroupId = DepartmentGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = DepartmentDelete,
                    Name = Delete,
                    Code = $"department.{Delete.ToLower()}",
                    GroupId = DepartmentGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = DepartmentManage,
                    Name = Manage,
                    Code = $"department.{Manage.ToLower()}",
                    GroupId = DepartmentGroup,
                    ModuleId = UserManagement
                },
                #endregion

                #region Profile
                new Permission {
                    Id = ProfileUpdate,
                    Name = Update,
                    Code = $"profile.{Update.ToLower()}",
                    GroupId = ProfileGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = ProfileView,
                    Name = View,
                    Code = $"profile.{View.ToLower()}",
                    GroupId = ProfileGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = ProfileManage,
                    Name = Manage,
                    Code = $"profile.{Manage.ToLower()}",
                    GroupId = ProfileGroup,
                    ModuleId = UserManagement
                },
                #endregion

                #region Library
                new Permission (LibraryCreate, Create, $"library.{Create.ToLower()}", LibraryGroup, LibraryManagement),
                new Permission (LibraryUpdate,  Update, $"library.{Update.ToLower()}", LibraryGroup, LibraryManagement),
                new Permission (LibraryList, List, $"library.{List.ToLower()}", LibraryGroup, LibraryManagement),
                new Permission (LibraryDelete,  Delete, $"library.{Delete.ToLower()}", LibraryGroup, LibraryManagement),
                new Permission (LibraryManage,  Manage, $"library.{Manage.ToLower()}", LibraryGroup, LibraryManagement),
                #endregion

                #region Library Member
                new Permission (LibraryMemberCreate, Create, $"library.member.{Create.ToLower()}", LibraryMemberGroup, LibraryManagement),
                new Permission (LibraryMemberUpdate,  Update, $"library.member.{Update.ToLower()}", LibraryMemberGroup, LibraryManagement),
                new Permission (LibraryMemberList, List, $"library.member.{List.ToLower()}", LibraryMemberGroup, LibraryManagement),
                new Permission (LibraryMemberDelete,  Delete, $"library.member.{Delete.ToLower()}", LibraryMemberGroup, LibraryManagement),
                new Permission (LibraryMemberManage,  Manage, $"library.member.{Manage.ToLower()}", LibraryMemberGroup, LibraryManagement),
                #endregion

                #region Library Member Request
                new Permission (LibraryMemberRequestCreate, Create, $"library.member.request.{Create.ToLower()}", LibraryMemberRequestGroup, LibraryManagement),
                new Permission (LibraryMemberRequestUpdate,  Update, $"library.member.request.{Update.ToLower()}", LibraryMemberRequestGroup, LibraryManagement),
                new Permission (LibraryMemberRequestList, List, $"library.member.request.{List.ToLower()}", LibraryMemberRequestGroup, LibraryManagement),
                new Permission (LibraryMemberRequestDelete,  Delete, $"library.member.request.{Delete.ToLower()}", LibraryMemberRequestGroup, LibraryManagement),
                new Permission (LibraryMemberRequestManage,  Manage, $"library.member.request.{Manage.ToLower()}", LibraryMemberRequestGroup, LibraryManagement),
                #endregion

                #region Card
                new Permission (CardCreate, Create, $"card.{Create.ToLower()}", CardGroup, LibraryManagement),
                new Permission (CardUpdate,  Update, $"card.{Update.ToLower()}", CardGroup, LibraryManagement),
                new Permission (CardList, List, $"card.{List.ToLower()}", CardGroup, LibraryManagement),
                new Permission (CardDelete,  Delete, $"card.{Delete.ToLower()}", CardGroup, LibraryManagement),
                new Permission (CardManage,  Manage, $"card.{Manage.ToLower()}", CardGroup, LibraryManagement),
                #endregion

                #region Book Catalog
                new Permission (BookCatalogCreate, Create, $"book.catalog.{Create.ToLower()}", BookCatalogGroup, LibraryManagement),
                new Permission (BookCatalogUpdate,  Update, $"book.catalog.{Update.ToLower()}", BookCatalogGroup, LibraryManagement),
                new Permission (BookCatalogList, List, $"book.catalog.{List.ToLower()}", BookCatalogGroup, LibraryManagement),
                new Permission (BookCatalogDelete,  Delete, $"book.catalog.{Delete.ToLower()}", BookCatalogGroup, LibraryManagement),
                new Permission (BookCatalogManage,  Manage, $"book.catalog.{Manage.ToLower()}", BookCatalogGroup, LibraryManagement),
                #endregion

                #region Book
                new Permission (BookCreate, Create, $"book.{Create.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookUpdate,  Update, $"book.{Update.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookView, View, $"book.{View.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookList, List, $"book.{List.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookDelete,  Delete, $"book.{Delete.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookManage,  Manage, $"book.{Manage.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookIssue,  Issue, $"book.{Issue.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookReturn,  Return, $"book.{Return.ToLower()}", BookGroup, LibraryManagement),
                #endregion

                #region Rack
                new Permission (RackCreate, Create, $"rack.{Create.ToLower()}", RackGroup, LibraryManagement),
                new Permission (RackUpdate,  Update, $"rack.{Update.ToLower()}", RackGroup, LibraryManagement),
                new Permission (RackList, List, $"rack.{List.ToLower()}", RackGroup, LibraryManagement),
                new Permission (RackDelete,  Delete, $"rack.{Delete.ToLower()}", RackGroup, LibraryManagement),
                new Permission (RackManage,  Manage, $"rack.{Manage.ToLower()}", RackGroup, LibraryManagement),
                #endregion

                #region Author
                new Permission (AuthorCreate, Create, $"author.{Create.ToLower()}", AuthorGroup, LibraryManagement),
                new Permission (AuthorUpdate,  Update, $"author.{Update.ToLower()}", AuthorGroup, LibraryManagement),
                new Permission (AuthorList, List, $"author.{List.ToLower()}", AuthorGroup, LibraryManagement),
                new Permission (AuthorDelete,  Delete, $"author.{Delete.ToLower()}", AuthorGroup, LibraryManagement),
                new Permission (AuthorManage,  Manage, $"author.{Manage.ToLower()}", AuthorGroup, LibraryManagement),
                #endregion

                #region Publisher
                new Permission (PublisherCreate, Create, $"publisher.{Create.ToLower()}", PublisherGroup, LibraryManagement),
                new Permission (PublisherUpdate,  Update, $"publisher.{Update.ToLower()}", PublisherGroup, LibraryManagement),
                new Permission (PublisherList, List, $"publisher.{List.ToLower()}", PublisherGroup, LibraryManagement),
                new Permission (PublisherDelete,  Delete, $"publisher.{Delete.ToLower()}", PublisherGroup, LibraryManagement),
                new Permission (PublisherManage,  Manage, $"publisher.{Manage.ToLower()}", PublisherGroup, LibraryManagement),
                #endregion

                #region Book Category
                new Permission (BookCategoryCreate, Create, $"book.category.{Create.ToLower()}", BookCategoryGroup, LibraryManagement),
                new Permission (BookCategoryUpdate,  Update, $"book.category.{Update.ToLower()}", BookCategoryGroup, LibraryManagement),
                new Permission (BookCategoryList, List, $"book.category.{List.ToLower()}", BookCategoryGroup, LibraryManagement),
                new Permission (BookCategoryDelete,  Delete, $"book.category.{Delete.ToLower()}", BookCategoryGroup, LibraryManagement),
                new Permission (BookCategoryManage,  Manage, $"book.category.{Manage.ToLower()}", BookCategoryGroup, LibraryManagement),
                #endregion

                #region Library Report
                new Permission (LibraryReportIssue, Issue, $"library.report.issue", LibraryReportGroup, LibraryManagement),
                new Permission (LibraryReportFine, Fine, $"library.report.fine", LibraryReportGroup, LibraryManagement),
                #endregion

                #region Asset
                new Permission (AssetCreate, Create, $"asset.{Create.ToLower()}", AssetGroup, AssetManagement),
                new Permission (AssetUpdate,  Update, $"asset.{Update.ToLower()}", AssetGroup, AssetManagement),
                new Permission (AssetList, List, $"asset.{List.ToLower()}", AssetGroup, AssetManagement),
                new Permission (AssetDelete,  Delete, $"asset.{Delete.ToLower()}", AssetGroup, AssetManagement),
                new Permission (AssetManage,  Manage, $"asset.{Manage.ToLower()}", AssetGroup, AssetManagement),
                #endregion

                #region Maintenance
                new Permission (MaintenanceCreate, Create, $"maintenance.{Create.ToLower()}", MaintenanceGroup, AssetManagement),
                new Permission (MaintenanceUpdate,  Update, $"maintenance.{Update.ToLower()}", MaintenanceGroup, AssetManagement),
                new Permission (MaintenanceList, List, $"maintenance.{List.ToLower()}", MaintenanceGroup, AssetManagement),
                new Permission (MaintenanceDelete,  Delete, $"maintenance.{Delete.ToLower()}", MaintenanceGroup, AssetManagement),
                new Permission (MaintenanceManage,  Manage, $"maintenance.{Manage.ToLower()}", MaintenanceGroup, AssetManagement),
                #endregion
            };
        }
    }
}
