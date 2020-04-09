namespace Module.Core.Data
{
    public static class PermissionConstants
    {
        public const long UserCreate = 100;
        public const long UserUpdate = 101;
        public const long UserView = 102;
        public const long UserDelete = 103;
        public const long UserList = 104;
        public const long UserManage = 105;
        public const long UserFilter = 106;

        public const long RoleCreate = 200;
        public const long RoleUpdate = 201;
        public const long RoleView = 202;
        public const long RoleDelete = 203;
        public const long RoleList = 204;
        public const long RoleManage = 205;
        public const long RoleFilter = 206;

        public const long DesignationCreate = 300;
        public const long DesignationUpdate = 301;
        public const long DesignationView = 302;
        public const long DesignationDelete = 303;
        public const long DesignationList = 304;
        public const long DesignationManage = 305;
        public const long DesignationFilter = 306;

        public const long DepartmentCreate = 400;
        public const long DepartmentUpdate = 401;
        public const long DepartmentView = 402;
        public const long DepartmentDelete = 403;
        public const long DepartmentList = 404;
        public const long DepartmentManage = 405;
        public const long DepartmentFilter = 406;

        public const long ProfileCreate = 500;
        public const long ProfileUpdate = 501;
        public const long ProfileView = 502;
        public const long ProfileDelete = 503;
        public const long ProfileList = 504;
        public const long ProfileManage = 505;
        public const long ProfileFilter = 506;

        public const long BookCreate = 600;
        public const long BookUpdate = 601;
        public const long BookView = 602;
        public const long BookDelete = 603;
        public const long BookList = 604;
        public const long BookManage = 605;
        public const long BookFilter= 606;

    }

    public static class PermissionGroupConstants
    {
        public const long UserGroup = 1;
        public const long RoleGroup = 2;
        public const long DesignationGroup = 3;
        public const long DepartmentGroup = 4;
        public const long ProfileGroup = 5;
        public const long BookGroup = 6;
    }

    public static class PermissionOperationConstants
    {
        public const string Create = "Create";
        public const string Update = "Update";
        public const string List = "List";
        public const string View = "View";
        public const string Delete = "Delete";
        public const string Filter = "Filter";
        public const string Manage = "Manage";
    }
}
