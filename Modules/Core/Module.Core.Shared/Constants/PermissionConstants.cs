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
        public const long RoleDelete = 203;
        public const long RoleList = 204;
        public const long RoleManage = 205;

        public const long DesignationCreate = 300;
        public const long DesignationUpdate = 301;
        public const long DesignationDelete = 303;
        public const long DesignationList = 304;
        public const long DesignationManage = 305;

        public const long DepartmentCreate = 400;
        public const long DepartmentUpdate = 401;
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
        public const long BookIssue = 606;
        public const long BookReturn= 607;

        public const long AuthorCreate = 700;
        public const long AuthorUpdate = 701;
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
        public const long SubjectDelete = 1003;
        public const long SubjectList = 1004;
        public const long SubjectManage = 1005;

        public const long EBookFormatView = 1100;
        public const long EBookFormatList = 1101;
        public const long EBookFormatManage = 1102;

        public const long PublisherCreate = 1200;
        public const long PublisherUpdate = 1201;
        public const long PublisherDelete = 1203;
        public const long PublisherList = 1204;
        public const long PublisherManage = 1205;

        public const long BookReservationView = 1300;
        public const long BookReservationList = 1301;
        public const long BookReservationManage = 1302;

        public const long LibraryCreate = 1400;
        public const long LibraryUpdate = 1401;
        public const long LibraryDelete = 1403;
        public const long LibraryList = 1404;
        public const long LibraryManage = 1405;

        public const long RackCreate = 1500;
        public const long RackUpdate = 1501;
        public const long RackDelete = 1503;
        public const long RackList = 1504;
        public const long RackManage = 1505;

        public const long OfficeCreate = 1600;
        public const long OfficeUpdate = 1601;
        public const long OfficeDelete = 1603;
        public const long OfficeList = 1604;
        public const long OfficeManage = 1605;

        public const long LibraryMemberCreate = 1700;
        public const long LibraryMemberUpdate = 1701;
        public const long LibraryMemberDelete = 1703;
        public const long LibraryMemberList = 1704;
        public const long LibraryMemberManage = 1705;

        public const long LibraryMemberRequestCreate = 1800;
        public const long LibraryMemberRequestUpdate = 1801;
        public const long LibraryMemberRequestDelete = 1803;
        public const long LibraryMemberRequestList = 1804;
        public const long LibraryMemberRequestManage = 1805;

        public const long CardCreate = 1900;
        public const long CardUpdate = 1901;
        public const long CardDelete = 1903;
        public const long CardList = 1904;
        public const long CardManage = 1905;

        public const long BookCatalogCreate = 2000;
        public const long BookCatalogUpdate = 2001;
        public const long BookCatalogDelete = 2003;
        public const long BookCatalogList = 2004;
        public const long BookCatalogManage = 2005;

        public const long BookCategoryCreate = 2100;
        public const long BookCategoryUpdate = 2101;
        public const long BookCategoryDelete = 2103;
        public const long BookCategoryList = 2104;
        public const long BookCategoryManage = 2105;

        public const long LibraryReportIssue = 2200;
        public const long LibraryReportFine = 2201;

        public const long AssetCreate = 2300;
        public const long AssetUpdate = 2301;
        public const long AssetDelete = 2303;
        public const long AssetList = 2304;
        public const long AssetManage = 2305;

        public const long MaintenanceCreate = 2400;
        public const long MaintenanceUpdate = 2401;
        public const long MaintenanceDelete = 2403;
        public const long MaintenanceList = 2404;
        public const long MaintenanceManage = 2405;

        public const long BookMemberStatusView = 2500;
        public const long BookMemberStatusList = 2501;
        public const long BookMemberStatusManage = 2502;

    }

    public static class PermissionGroupConstants
    {
        public const long UserGroup = 1;
        public const long RoleGroup = 2;
        public const long DesignationGroup = 3;
        public const long DepartmentGroup = 4;
        public const long ProfileGroup = 5;
        public const long BookGroup = 6;
        public const long LibraryGroup = 7;
        public const long LibraryMemberGroup = 8;
        public const long LibraryMemberRequestGroup = 9;
        public const long CardGroup = 10;
        public const long BookCatalogGroup = 11;
        public const long RackGroup = 12;
        public const long AuthorGroup = 13;
        public const long PublisherGroup = 14;
        public const long BookCategoryGroup = 15;
        public const long LibraryReportGroup = 16;
        public const long AssetGroup = 17;
        public const long MaintenanceGroup = 18;
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
        public const string Issue = "Issue";
        public const string Return = "Return";
        public const string Fine = "Fine";
    }
}
