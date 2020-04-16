namespace Module.Core.Shared
{
    public static class PermissionConstants
    {
        public const long UserCreate = 100;
        public const long UserUpdate = 101;
        public const long UserView = 102;
        public const long UserDelete = 103;
        public const long UserList = 104;
        public const long UserManage = 105;

        public const long RoleCreate = 200;
        public const long RoleUpdate = 201;
        public const long RoleView = 202;
        public const long RoleDelete = 203;
        public const long RoleList = 204;
        public const long RoleManage = 205;

        public const long DesignationCreate = 300;
        public const long DesignationUpdate = 301;
        public const long DesignationView = 302;
        public const long DesignationDelete = 303;
        public const long DesignationList = 304;
        public const long DesignationManage = 305;

        public const long DepartmentCreate = 400;
        public const long DepartmentUpdate = 401;
        public const long DepartmentView = 402;
        public const long DepartmentDelete = 403;
        public const long DepartmentList = 404;
        public const long DepartmentManage = 405;

        public const long ProfileUpdate = 501;
        public const long ProfileView = 502;
        public const long ProfileManage = 505;

        public const long BookCreate = 600;
        public const long BookUpdate = 601;
        public const long BookView = 602;
        public const long BookDelete = 603;
        public const long BookList = 604;
        public const long BookManage = 605;

        public const long AuthorCreate = 700;
        public const long AuthorUpdate = 701;
        public const long AuthorView = 702;
        public const long AuthorDelete = 703;
        public const long AuthorList = 704;
        public const long AuthorManage = 705;

        public const long BookFormatView = 800;
        public const long BookFormatList = 801;
        public const long BookFormatManage = 802;

        public const long BookStatusView = 900;
        public const long BookStatusList = 901;
        public const long BookStatusManage = 902;

        public const long SubjectCreate = 1000;
        public const long SubjectUpdate = 1001;
        public const long SubjectView = 1002;
        public const long SubjectDelete = 1003;
        public const long SubjectList = 1004;
        public const long SubjectManage = 1005;

        public const long EBookFormatView = 1100;
        public const long EBookFormatList = 1101;
        public const long EBookFormatManage = 1102;

        public const long BookMemberStatusView = 1100;
        public const long BookMemberStatusList = 1101;
        public const long BookMemberStatusManage = 1102;

        public const long PublisherCreate = 1200;
        public const long PublisherUpdate = 1201;
        public const long PublisherView = 1202;
        public const long PublisherDelete = 1203;
        public const long PublisherList = 1204;
        public const long PublisherManage = 1205;

        public const long BookReservationView = 1300;
        public const long BookReservationList = 1301;
        public const long BookReservationManage = 1302;

        public const long LibraryCreate = 1400;
        public const long LibraryUpdate = 1401;
        public const long LibraryView = 1402;
        public const long LibraryDelete = 1403;
        public const long LibraryList = 1404;
        public const long LibraryManage = 1405;

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
