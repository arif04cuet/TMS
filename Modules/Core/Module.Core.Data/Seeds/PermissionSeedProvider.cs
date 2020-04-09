using Infrastructure.Data;
using Module.Core.Entities;
using System.Collections.Generic;
using static Module.Core.Data.PermissionConstants;
using static Module.Core.Data.PermissionGroupConstants;
using static Module.Core.Data.PermissionOperationConstants;
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
                new Permission (UserFilter,  Filter, $"user.{Filter.ToLower()}", UserGroup, UserManagement),
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
                    Id = RoleView,
                    Name = View,
                    Code = $"role.{View.ToLower()}",
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
                new Permission {
                    Id = RoleFilter,
                    Name = Filter,
                    Code = $"role.{Filter.ToLower()}",
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
                    Id = DesignationView,
                    Name = View,
                    Code = $"designation.{View.ToLower()}",
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
                new Permission {
                    Id = DesignationFilter,
                    Name = Filter,
                    Code = $"designation.{Filter.ToLower()}",
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
                    Id = DepartmentView,
                    Name = View,
                    Code = $"department.{View.ToLower()}",
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
                new Permission {
                    Id = DepartmentFilter,
                    Name = Filter,
                    Code = $"department.{Filter.ToLower()}",
                    GroupId = DepartmentGroup,
                    ModuleId = UserManagement
                },
                #endregion

                #region Profile
                new Permission {
                    Id = ProfileCreate,
                    Name = Create,
                    Code = $"profile.{Create.ToLower()}",
                    GroupId = ProfileGroup,
                    ModuleId = UserManagement
                },
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
                    Id = ProfileList,
                    Name = List,
                    Code = $"profile.{List.ToLower()}",
                    GroupId = ProfileGroup,
                    ModuleId = UserManagement
                },
                new Permission {
                    Id = ProfileDelete,
                    Name = Delete,
                    Code = $"profile.{Delete.ToLower()}",
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
                new Permission {
                    Id = ProfileFilter,
                    Name = Filter,
                    Code = $"profile.{Filter.ToLower()}",
                    GroupId = ProfileGroup,
                    ModuleId = UserManagement
                },
                #endregion

                #region Book
                new Permission (BookCreate, Create, $"book.{Create.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookUpdate,  Update, $"book.{Update.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookView, View, $"book.{View.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookList, List, $"book.{List.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookDelete,  Delete, $"book.{Delete.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookManage,  Manage, $"book.{Manage.ToLower()}", BookGroup, LibraryManagement),
                new Permission (BookFilter,  Filter, $"book.{Filter.ToLower()}", BookGroup, LibraryManagement),
                #endregion
            };
        }
    }
}
