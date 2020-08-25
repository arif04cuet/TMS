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

        //Asset
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


        public const long AssetAuditCreate = 2406;
        public const long AssetBulkCheckoutCreate = 2407;
        
        //license
        public const long LicenseCreate = 2408;
        public const long LicenseUpdate = 2409;
        public const long LicenseDelete = 2410;
        public const long LicenseList = 2411;
        public const long LicenseManage = 2412;

        //consumable
        public const long ConsumableCreate = 2420;
        public const long ConsumableUpdate = 2421;
        public const long ConsumableDelete = 2422;
        public const long ConsumableList = 2423;
        public const long ConsumableManage = 2424;

        // setting asset model

        public const long AssetModelCreate = 2440;
        public const long AssetModelUpdate = 2441;
        public const long AssetModelDelete = 2442;
        public const long AssetModelList = 2443;      
        public const long AssetModelManage = 2444;

        // setting item code

        public const long ItemCodeCreate = 2450;
        public const long ItemCodeUpdate = 2451;
        public const long ItemCodeDelete = 2452;
        public const long ItemCodeList = 2453;      
        public const long ItemCodeManage = 2454;

        // setting item code

        public const long SupplierCreate = 2460;
        public const long SupplierUpdate = 2461;
        public const long SupplierDelete = 2462;
        public const long SupplierManage = 2464;
        public const long SupplierList   = 2463;      
        
        // setting depreciation

        public const long DepreciationCreate = 2470;
        public const long DepreciationUpdate = 2471;
        public const long DepreciationDelete = 2472;
        public const long DepreciationManage = 2474;
        public const long DepreciationList   = 2473;      

        // setting manufacturer

        public const long ManufacturerCreate = 2480;
        public const long ManufacturerUpdate = 2481;
        public const long ManufacturerDelete = 2482;
        public const long ManufacturerManage = 2484;
        public const long ManufacturerList   = 2483;      

        // Asset Reports
        public const long ReportActivityLog = 2584;
        public const long ReportAuditLog    = 2485;
        public const long ReportDepreciation= 2486;
        public const long ReportLicense     = 2487;
        public const long ReportMaintenance = 2488;   
        public const long ReportAsset       = 2489;   
        

        // setting asset.status

        public const long AssetStatusCreate = 2490;
        public const long AssetStatusUpdate = 2491;
        public const long AssetStatusDelete = 2492;
        public const long AssetStatusManage = 2494;
        public const long AssetStatusList   = 2493;  

        // setting category

        public const long AssetCategoryCreate = 2594;
        public const long AssetCategoryUpdate = 2495;
        public const long AssetCategoryDelete = 2496;
        public const long AssetCategoryManage = 2497;
        public const long AssetCategoryList   = 2498;  


        public const long BookMemberStatusView = 2500;
        public const long BookMemberStatusList = 2501;
        public const long BookMemberStatusManage = 2502;

        

        //CMS

        //category
        public const long ContentCategoryCreate = 2600;
        public const long ContentCategoryUpdate = 2601;
        public const long ContentCategoryDelete = 2602;
        public const long ContentCategoryList = 2603;
        public const long ContentCategoryManage = 2604;

        //contents
        public const long ContentsUpdate = 2700;
        public const long ContentsCreate = 2701;
        public const long ContentsDelete = 2702;
        public const long ContentsList = 2703;
        public const long ContentsManage = 2704;

        //Faq
        public const long ContentFaqUpdate = 2800;
        public const long ContentFaqDelete = 2801;
        public const long ContentFaqCreate = 2802;
        public const long ContentFaqList = 2803;
        public const long ContentFaqManage = 2804;

        //Banner
        public const long ContentBannerCreate = 2900;
        public const long ContentBannerUpdate = 2901;
        public const long ContentBannerDelete = 2902;
        public const long ContentBannerList = 2903;
        public const long ContentBannerManage = 2904;


        //Hostel

        //Allocation
        public const long HostelAllocationCreate = 3001;
        public const long HostelAllocationUpdate = 3002;
        public const long HostelAllocationDelete = 3003;
        public const long HostelAllocationManage = 3004;
        public const long HostelAllocationList   = 3005;          

        //hostel
        public const long HostelHostelCreate = 3101;
        public const long HostelHostelUpdate = 3102;
        public const long HostelHostelDelete = 3103;
        public const long HostelHostelManage = 3104;
        public const long HostelHostelList   = 3105;  

        //Building
        public const long HostelBuildingCreate = 3201;
        public const long HostelBuildingUpdate = 3202;
        public const long HostelBuildingDelete = 3203;
        public const long HostelBuildingManage = 3204;
        public const long HostelBuildingList   = 3205;  

        //Room
        public const long HostelRoomCreate = 3301;
        public const long HostelRoomUpdate = 3302;
        public const long HostelRoomDelete = 3303;
        public const long HostelRoomManage = 3304;
        public const long HostelRoomList   = 3305;  

        //Bed
        public const long HostelBedCreate = 3401;
        public const long HostelBedUpdate = 3402;
        public const long HostelBedDelete = 3403;
        public const long HostelBedManage = 3404;
        public const long HostelBedList   = 3405;  

        //room.type
        public const long HostelRoomTypeCreate = 3501;
        public const long HostelRoomTypeUpdate = 3502;
        public const long HostelRoomTypeDelete = 3503;
        public const long HostelRoomTypeManage = 3504;
        public const long HostelRoomTypeList   = 3505;  

        //room.facilities
        public const long HostelRoomFacilitiesCreate = 3601;
        public const long HostelRoomFacilitiesUpdate = 3602;
        public const long HostelRoomFacilitiesDelete = 3603;
        public const long HostelRoomFacilitiesManage = 3604;
        public const long HostelRoomFacilitiesList   = 3605;  

        //Training

        //course
        public const long TrainingCourseCreate = 3701;
        public const long TrainingCourseUpdate = 3702;
        public const long TrainingCourseDelete = 3703;
        public const long TrainingCourseManage = 3704;
        public const long TrainingCourseList   = 3705;  

        //module
        public const long TrainingModuleCreate = 3801;
        public const long TrainingModuleUpdate = 3802;
        public const long TrainingModuleDelete = 3803;
        public const long TrainingModuleManage = 3804;
        public const long TrainingModuleList   = 3805;  
        
        //topic
        public const long TrainingTopicCreate = 3901;
        public const long TrainingTopicUpdate = 3902;
        public const long TrainingTopicDelete = 3903;
        public const long TrainingTopicManage = 3904;
        public const long TrainingTopicList   = 3905; 

        //course.category
        public const long TrainingCourseCategoryCreate = 4001;
        public const long TrainingCourseCategoryUpdate = 4002;
        public const long TrainingCourseCategoryDelete = 4003;
        public const long TrainingCourseCategoryManage = 4004;
        public const long TrainingCourseCategoryList   = 4005; 

        //method
        public const long TrainingMethodCreate = 4101;
        public const long TrainingMethodUpdate = 4102;
        public const long TrainingMethodDelete = 4103;
        public const long TrainingMethodManage = 4104;
        public const long TrainingMethodList   = 4105; 


        //evaluation.method
        public const long TrainingEvaluationMethodCreate = 4201;
        public const long TrainingEvaluationMethodUpdate = 4202;
        public const long TrainingEvaluationMethodDelete = 4203;
        public const long TrainingEvaluationMethodManage = 4204;
        public const long TrainingEvaluationMethodList   = 4205; 


        //grade
        public const long TrainingGradeCreate = 4301;
        public const long TrainingGradeUpdate = 4302;
        public const long TrainingGradeDelete = 4303;
        public const long TrainingGradeManage = 4304;
        public const long TrainingGradeList   = 4305; 

        //expertise
        public const long TrainingExpertiseCreate = 4401;
        public const long TrainingExpertiseUpdate = 4402;
        public const long TrainingExpertiseDelete = 4403;
        public const long TrainingExpertiseManage = 4404;
        public const long TrainingExpertiseList   = 4405; 

        //resource.person
        public const long TrainingResourcePersonCreate = 4501;
        public const long TrainingResourcePersonUpdate = 4502;
        public const long TrainingResourcePersonDelete = 4503;
        public const long TrainingResourcePersonManage = 4504;
        public const long TrainingResourcePersonList   = 4505; 

        //schedule
        public const long TrainingScheduleCreate = 4601;
        public const long TrainingScheduleUpdate = 4602;
        public const long TrainingScheduleDelete = 4603;
        public const long TrainingScheduleManage = 4604;
        public const long TrainingScheduleList   = 4605; 

        //batch
        public const long TrainingBatchCreate = 4701;
        public const long TrainingBatchUpdate = 4702;
        public const long TrainingBatchDelete = 4703;
        public const long TrainingBatchManage = 4704;
        public const long TrainingBatchList   = 4705; 

        //batch.allocation
        public const long TrainingBatchAllocationCreate = 4801;
        public const long TrainingBatchAllocationUpdate = 4802;
        public const long TrainingBatchAllocationDelete = 4803;
        public const long TrainingBatchAllocationManage = 4804;
        public const long TrainingBatchAllocationList   = 4805; 

        //question
        public const long TrainingQuestionCreate = 4901;
        public const long TrainingQuestionUpdate = 4902;
        public const long TrainingQuestionDelete = 4903;
        public const long TrainingQuestionManage = 4904;
        public const long TrainingQuestionList   = 4905; 

        //honorarium.head
        public const long TrainingHonorariumHeadCreate = 5101;
        public const long TrainingHonorariumHeadUpdate = 5102;
        public const long TrainingHonorariumHeadDelete = 5103;
        public const long TrainingHonorariumHeadManage = 5104;
        public const long TrainingHonorariumHeadList   = 5105; 

        //Others
        public const long MyExamManage = 6100;

        //asset requisition
        public const long AssetRequisitionCreate = 7101;
        public const long AssetRequisitionUpdate = 7102;
        public const long AssetRequisitionDelete = 7103;
        public const long AssetRequisitionManage = 7104;
        public const long AssetRequisitionList   = 7105; 


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
        
        //Asset
        public const long AssetGroup = 17;
        public const long MaintenanceGroup = 18;
        
        
        //CMS
        public const long ContentCategoryGroup = 19;
        public const long ContentsGroup = 20;
        public const long ContentFaqGroup = 21;

        public const long ContentBannerGroup = 22;

        //asset
        public const long LicenseGroup = 23;
        public const long ConsumableGroup = 24;

        public const long SettingGroup = 25;
        public const long AssetReportGroup = 26;

        //Hostel
        public const long HostelAllocationGroup = 27;
        public const long HostelHostelGroup = 28;
        public const long HostelBuildingGroup = 29;
        public const long HostelRoomGroup = 30;
        public const long HostelBedGroup = 31;
        public const long HostelRoomTypeGroup = 32;
        public const long HostelRoomFacilitiesGroup = 33;

        //Training
        public const long TrainingCourseGroup           = 40;
        public const long TrainingModuleGroup           = 41;
        public const long TrainingTopicGroup            = 42;
        public const long TrainingCourseCategoryGroup   = 43;
        public const long TrainingMethodGroup           = 44;
        public const long TrainingEvaluationMethodGroup = 45;
        public const long TrainingGradeGroup            = 46;
        public const long TrainingExpertiseGroup        = 47;
        public const long TrainingResourcePersonGroup   = 48;

        public const long TrainingScheduleGroup         = 50;
        public const long TrainingBatchGroup            = 51;
        public const long TrainingBatchAllocationGroup  = 52;
        public const long TrainingQuestionGroup         = 53;
        public const long TrainingHonorariumHeadGroup   = 54;

        public const long OthersGroup   = 55;
        public const long AssetRequisitionGroup   = 56;
        public const long OfficeGroup = 57;


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
        public const string Checkout = "Checkout";
        public const string Audit = "Audit";
        public const string BulkCheckout = "Bulk Checkout";
    }
}
