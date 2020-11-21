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

                #region Office
                new Permission (OfficeCreate,   Create, $"office.{Create.ToLower()}",  OfficeGroup, UserManagement),
                new Permission (OfficeUpdate,   Update, $"office.{Update.ToLower()}",  OfficeGroup, UserManagement),
                new Permission (OfficeList,     List,   $"office.{List.ToLower()}",    OfficeGroup, UserManagement),
                new Permission (OfficeDelete,   Delete, $"office.{Delete.ToLower()}",  OfficeGroup, UserManagement),
                new Permission (OfficeManage,   Manage, $"office.{Manage.ToLower()}",  OfficeGroup, UserManagement),
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

                #region Book Reservation
                new Permission (BookReservationCreate, Create, $"book.reservation.{Create.ToLower()}", BookReservationGroup, LibraryManagement),
                new Permission (BookReservationUpdate,  Update, $"book.reservation.{Update.ToLower()}", BookReservationGroup, LibraryManagement),
                new Permission (BookReservationView, View, $"book.reservation.{View.ToLower()}", BookReservationGroup, LibraryManagement),
                new Permission (BookReservationList, List, $"book.reservation.{List.ToLower()}", BookReservationGroup, LibraryManagement),
                new Permission (BookReservationDelete,  Delete, $"book.reservation.{Delete.ToLower()}", BookReservationGroup, LibraryManagement),
                new Permission (BookReservationManage,  Manage, $"book.reservation.{Manage.ToLower()}", BookReservationGroup, LibraryManagement),
                new Permission (BookReservationCancel,  Manage, $"book.reservation.{Cancel.ToLower()}", BookReservationGroup, LibraryManagement),
                new Permission (BookReservationIssue,  Manage, $"book.reservation.{Issue.ToLower()}", BookReservationGroup, LibraryManagement),
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
                new Permission (LibraryReportBookEntry, BookEntry, $"library.report.book.entry", LibraryReportGroup, LibraryManagement),
                new Permission (LibraryReportAtAGlance, AtAGlance, $"library.report.at.a.glance", LibraryReportGroup, LibraryManagement),
                new Permission (LibraryReportLostBook, LostBook, $"library.report.lost.books", LibraryReportGroup, LibraryManagement),
                new Permission (LibraryReportNewBook, NewBook, $"library.report.new.books", LibraryReportGroup, LibraryManagement),
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

                #region Asset Audit
                new Permission (AssetAuditCreate, Audit, $"asset.audit.{Create.ToLower()}", AssetGroup, AssetManagement),
                new Permission (AssetBulkCheckoutCreate, BulkCheckout, $"asset.bulk.{Checkout.ToLower()}", AssetGroup, AssetManagement),
                #endregion

                #region License
                new Permission (LicenseCreate,   Create, $"license.{Create.ToLower()}",  LicenseGroup, AssetManagement),
                new Permission (LicenseUpdate,   Update, $"license.{Update.ToLower()}",  LicenseGroup, AssetManagement),
                new Permission (LicenseList,     List,   $"license.{List.ToLower()}",    LicenseGroup, AssetManagement),
                new Permission (LicenseDelete,   Delete, $"license.{Delete.ToLower()}",  LicenseGroup, AssetManagement),
                new Permission (LicenseManage,   Manage, $"license.{Manage.ToLower()}",  LicenseGroup, AssetManagement),
                #endregion

                #region Asset Consumable
                new Permission (ConsumableCreate,   Create, $"consumable.{Create.ToLower()}", ConsumableGroup, AssetManagement),
                new Permission (ConsumableUpdate,   Update, $"consumable.{Update.ToLower()}", ConsumableGroup, AssetManagement),
                new Permission (ConsumableList,     List,   $"consumable.{List.ToLower()}", ConsumableGroup, AssetManagement),
                new Permission (ConsumableDelete,   Delete, $"consumable.{Delete.ToLower()}", ConsumableGroup, AssetManagement),
                new Permission (ConsumableManage,   Manage, $"consumable.{Manage.ToLower()}", ConsumableGroup, AssetManagement),
                #endregion

                #region Asset Settings asset model
                new Permission (AssetModelCreate,   Create, $"asset.model.{Create.ToLower()}",  AssetSettingModelGroup, AssetManagement),
                new Permission (AssetModelUpdate,   Update, $"asset.model.{Update.ToLower()}",  AssetSettingModelGroup, AssetManagement),
                new Permission (AssetModelList,     List,   $"asset.model.{List.ToLower()}",    AssetSettingModelGroup, AssetManagement),
                new Permission (AssetModelDelete,   Delete, $"asset.model.{Delete.ToLower()}",  AssetSettingModelGroup, AssetManagement),
                new Permission (AssetModelManage,   Manage, $"asset.model.{Manage.ToLower()}",  AssetSettingModelGroup, AssetManagement),
                #endregion

                #region Asset Settings Item Code
                new Permission (ItemCodeCreate,   Create, $"item.code.{Create.ToLower()}",      AssetSettingItemCodeGroup, AssetManagement),
                new Permission (ItemCodeUpdate,   Update, $"item.code.{Update.ToLower()}",      AssetSettingItemCodeGroup, AssetManagement),
                new Permission (ItemCodeList,     List,   $"item.code.{List.ToLower()}",        AssetSettingItemCodeGroup, AssetManagement),
                new Permission (ItemCodeDelete,   Delete, $"item.code.{Delete.ToLower()}",      AssetSettingItemCodeGroup, AssetManagement),
                new Permission (ItemCodeManage,   Manage, $"item.code.{Manage.ToLower()}",      AssetSettingItemCodeGroup, AssetManagement),
                #endregion

                #region Asset Settings supplier
                new Permission (SupplierCreate,   Create, $"supplier.{Create.ToLower()}",   AssetSettingSupplierGroup, AssetManagement),
                new Permission (SupplierUpdate,   Update, $"supplier.{Update.ToLower()}",   AssetSettingSupplierGroup, AssetManagement),
                new Permission (SupplierList,     List,   $"supplier.{List.ToLower()}",     AssetSettingSupplierGroup, AssetManagement),
                new Permission (SupplierDelete,   Delete, $"supplier.{Delete.ToLower()}",   AssetSettingSupplierGroup, AssetManagement),
                new Permission (SupplierManage,   Manage, $"supplier.{Manage.ToLower()}",   AssetSettingSupplierGroup, AssetManagement),
                #endregion
                
                #region Asset Settings depreciation
                new Permission (DepreciationCreate,   Create, $"depreciation.{Create.ToLower()}",   AssetSettingDepreciationGroup, AssetManagement),
                new Permission (DepreciationUpdate,   Update, $"depreciation.{Update.ToLower()}",   AssetSettingDepreciationGroup, AssetManagement),
                new Permission (DepreciationList,     List,   $"depreciation.{List.ToLower()}",     AssetSettingDepreciationGroup, AssetManagement),
                new Permission (DepreciationDelete,   Delete, $"depreciation.{Delete.ToLower()}",   AssetSettingDepreciationGroup, AssetManagement),
                new Permission (DepreciationManage,   Manage, $"depreciation.{Manage.ToLower()}",   AssetSettingDepreciationGroup, AssetManagement),
                #endregion

                #region Asset Settings manufacturer
                new Permission (ManufacturerCreate,   Create, $"manufacturer.{Create.ToLower()}",  AssetSettingManufacturerGroup, AssetManagement),
                new Permission (ManufacturerUpdate,   Update, $"manufacturer.{Update.ToLower()}",  AssetSettingManufacturerGroup, AssetManagement),
                new Permission (ManufacturerList,     List,   $"manufacturer.{List.ToLower()}",    AssetSettingManufacturerGroup, AssetManagement),
                new Permission (ManufacturerDelete,   Delete, $"manufacturer.{Delete.ToLower()}",  AssetSettingManufacturerGroup, AssetManagement),
                new Permission (ManufacturerManage,   Manage, $"manufacturer.{Manage.ToLower()}",  AssetSettingManufacturerGroup, AssetManagement),
                #endregion

                #region Asset Settings asset.status
                new Permission (AssetStatusCreate,   Create, $"asset.status.{Create.ToLower()}",  AssetSettingStatusGroup, AssetManagement),
                new Permission (AssetStatusUpdate,   Update, $"asset.status.{Update.ToLower()}",  AssetSettingStatusGroup, AssetManagement),
                new Permission (AssetStatusList,     List,   $"asset.status.{List.ToLower()}",    AssetSettingStatusGroup, AssetManagement),
                new Permission (AssetStatusDelete,   Delete, $"asset.status.{Delete.ToLower()}",  AssetSettingStatusGroup, AssetManagement),
                new Permission (AssetStatusManage,   Manage, $"asset.status.{Manage.ToLower()}",  AssetSettingStatusGroup, AssetManagement),
                #endregion

                #region Asset Settings asset.category
                new Permission (AssetCategoryCreate,   Create, $"asset.category.{Create.ToLower()}",  AssetSettingStatusGroup, AssetManagement),
                new Permission (AssetCategoryUpdate,   Update, $"asset.category.{Update.ToLower()}",  AssetSettingStatusGroup, AssetManagement),
                new Permission (AssetCategoryList,     List,   $"asset.category.{List.ToLower()}",    AssetSettingStatusGroup, AssetManagement),
                new Permission (AssetCategoryDelete,   Delete, $"asset.category.{Delete.ToLower()}",  AssetSettingStatusGroup, AssetManagement),
                new Permission (AssetCategoryManage,   Manage, $"asset.category.{Manage.ToLower()}",  AssetSettingStatusGroup, AssetManagement),
                #endregion

                #region Asset Report
                new Permission (ReportActivityLog,      AssetReportActivityLog , $"report.activity.log",  AssetReportGroup, AssetManagement),
                new Permission (ReportAuditLog,         AssetReportAuditLog    , $"report.audit.log",     AssetReportGroup, AssetManagement),
                new Permission (ReportDepreciation,     AssetReportDepreciation, $"report.depreciation",  AssetReportGroup, AssetManagement),
                new Permission (ReportLicense,          AssetReportLicense     , $"report.license",       AssetReportGroup, AssetManagement),
                new Permission (ReportMaintenance,      AssetReportMaintenance , $"report.maintenance",   AssetReportGroup, AssetManagement),
                new Permission (ReportAsset,            AssetReportAsset       , $"report.asset",         AssetReportGroup, AssetManagement),
                #endregion

                #region Asset Requisition
                new Permission (AssetRequisitionCreate,   Create, $"requisition.{Create.ToLower()}",  AssetRequisitionGroup, AssetManagement),
                new Permission (AssetRequisitionUpdate,   Update, $"requisition.{Update.ToLower()}",  AssetRequisitionGroup, AssetManagement),
                new Permission (AssetRequisitionList,     List,   $"requisition.{List.ToLower()}",    AssetRequisitionGroup, AssetManagement),
                new Permission (AssetRequisitionDelete,   Delete, $"requisition.{Delete.ToLower()}",  AssetRequisitionGroup, AssetManagement),
                new Permission (AssetRequisitionManage,   Manage, $"requisition.{Manage.ToLower()}",  AssetRequisitionGroup, AssetManagement),
                #endregion

                #region ContentCategory
                new Permission (ContentCategoryCreate, Create, $"content.category.{Create.ToLower()}", ContentCategoryGroup, CmsManagement),
                new Permission (ContentCategoryUpdate,  Update, $"content.category.{Update.ToLower()}", ContentCategoryGroup, CmsManagement),
                new Permission (ContentCategoryList, List, $"content.category.{List.ToLower()}", ContentCategoryGroup, CmsManagement),
                new Permission (ContentCategoryDelete,  Delete, $"content.category.{Delete.ToLower()}", ContentCategoryGroup, CmsManagement),
                new Permission (ContentCategoryManage,  Manage, $"content.category.{Manage.ToLower()}", ContentCategoryGroup, CmsManagement),
                #endregion

                #region Contents
                new Permission (ContentsCreate, Create, $"content.{Create.ToLower()}", ContentsGroup, CmsManagement),
                new Permission (ContentsUpdate,  Update, $"content.{Update.ToLower()}", ContentsGroup, CmsManagement),
                new Permission (ContentsList, List, $"content.{List.ToLower()}", ContentsGroup, CmsManagement),
                new Permission (ContentsDelete,  Delete, $"content.{Delete.ToLower()}", ContentsGroup, CmsManagement),
                new Permission (ContentsManage,  Manage, $"content.{Manage.ToLower()}", ContentsGroup, CmsManagement),
                #endregion

                #region ContentFaq
                new Permission (ContentFaqCreate, Create, $"content.faq.{Create.ToLower()}", ContentFaqGroup, CmsManagement),
                new Permission (ContentFaqUpdate,  Update, $"content.faq.{Update.ToLower()}", ContentFaqGroup, CmsManagement),
                new Permission (ContentFaqList, List, $"content.faq.{List.ToLower()}", ContentFaqGroup, CmsManagement),
                new Permission (ContentFaqDelete,  Delete, $"content.faq.{Delete.ToLower()}", ContentFaqGroup, CmsManagement),
                new Permission (ContentFaqManage,  Manage, $"content.faq.{Manage.ToLower()}", ContentFaqGroup, CmsManagement),
                #endregion

                #region ContentBanner
                new Permission (ContentBannerCreate, Create, $"content.banner.{Create.ToLower()}", ContentBannerGroup, CmsManagement),
                new Permission (ContentBannerUpdate,  Update, $"content.banner.{Update.ToLower()}", ContentBannerGroup, CmsManagement),
                new Permission (ContentBannerList, List, $"content.banner.{List.ToLower()}", ContentBannerGroup, CmsManagement),
                new Permission (ContentBannerDelete,  Delete, $"content.banner.{Delete.ToLower()}", ContentBannerGroup, CmsManagement),
                new Permission (ContentBannerManage,  Manage, $"content.banner.{Manage.ToLower()}", ContentBannerGroup, CmsManagement),
                #endregion

                #region Hostel Allocation
                new Permission (HostelAllocationCreate,   Create, $"allocation.{Create.ToLower()}",  HostelAllocationGroup, HostelManagement),
                new Permission (HostelAllocationUpdate,   Update, $"allocation.{Update.ToLower()}",  HostelAllocationGroup, HostelManagement),
                new Permission (HostelAllocationList,     List,   $"allocation.{List.ToLower()}",    HostelAllocationGroup, HostelManagement),
                new Permission (HostelAllocationDelete,   Delete, $"allocation.{Delete.ToLower()}",  HostelAllocationGroup, HostelManagement),
                new Permission (HostelAllocationManage,   Manage, $"allocation.{Manage.ToLower()}",  HostelAllocationGroup, HostelManagement),
                #endregion
                
                #region Hostel Hostel
                new Permission (HostelHostelCreate,   Create, $"hostel.{Create.ToLower()}",  HostelHostelGroup, HostelManagement),
                new Permission (HostelHostelUpdate,   Update, $"hostel.{Update.ToLower()}",  HostelHostelGroup, HostelManagement),
                new Permission (HostelHostelList,     List,   $"hostel.{List.ToLower()}",    HostelHostelGroup, HostelManagement),
                new Permission (HostelHostelDelete,   Delete, $"hostel.{Delete.ToLower()}",  HostelHostelGroup, HostelManagement),
                new Permission (HostelHostelManage,   Manage, $"hostel.{Manage.ToLower()}",  HostelHostelGroup, HostelManagement),
                #endregion
                
                #region Hostel Building
                new Permission (HostelBuildingCreate,   Create, $"building.{Create.ToLower()}",  HostelBuildingGroup, HostelManagement),
                new Permission (HostelBuildingUpdate,   Update, $"building.{Update.ToLower()}",  HostelBuildingGroup, HostelManagement),
                new Permission (HostelBuildingList,     List,   $"building.{List.ToLower()}",    HostelBuildingGroup, HostelManagement),
                new Permission (HostelBuildingDelete,   Delete, $"building.{Delete.ToLower()}",  HostelBuildingGroup, HostelManagement),
                new Permission (HostelBuildingManage,   Manage, $"building.{Manage.ToLower()}",  HostelBuildingGroup, HostelManagement),
                #endregion

                #region Hostel Room
                new Permission (HostelRoomCreate,   Create, $"room.{Create.ToLower()}",  HostelRoomGroup, HostelManagement),
                new Permission (HostelRoomUpdate,   Update, $"room.{Update.ToLower()}",  HostelRoomGroup, HostelManagement),
                new Permission (HostelRoomList,     List,   $"room.{List.ToLower()}",    HostelRoomGroup, HostelManagement),
                new Permission (HostelRoomDelete,   Delete, $"room.{Delete.ToLower()}",  HostelRoomGroup, HostelManagement),
                new Permission (HostelRoomManage,   Manage, $"room.{Manage.ToLower()}",  HostelRoomGroup, HostelManagement),
                #endregion

                #region Hostel Bed
                new Permission (HostelBedCreate,   Create, $"bed.{Create.ToLower()}",  HostelBedGroup, HostelManagement),
                new Permission (HostelBedUpdate,   Update, $"bed.{Update.ToLower()}",  HostelBedGroup, HostelManagement),
                new Permission (HostelBedList,     List,   $"bed.{List.ToLower()}",    HostelBedGroup, HostelManagement),
                new Permission (HostelBedDelete,   Delete, $"bed.{Delete.ToLower()}",  HostelBedGroup, HostelManagement),
                new Permission (HostelBedManage,   Manage, $"bed.{Manage.ToLower()}",  HostelBedGroup, HostelManagement),
                #endregion

                #region Hostel room.type
                new Permission (HostelRoomTypeCreate,   Create, $"room.type.{Create.ToLower()}",  HostelRoomTypeGroup, HostelManagement),
                new Permission (HostelRoomTypeUpdate,   Update, $"room.type.{Update.ToLower()}",  HostelRoomTypeGroup, HostelManagement),
                new Permission (HostelRoomTypeList,     List,   $"room.type.{List.ToLower()}",    HostelRoomTypeGroup, HostelManagement),
                new Permission (HostelRoomTypeDelete,   Delete, $"room.type.{Delete.ToLower()}",  HostelRoomTypeGroup, HostelManagement),
                new Permission (HostelRoomTypeManage,   Manage, $"room.type.{Manage.ToLower()}",  HostelRoomTypeGroup, HostelManagement),
                #endregion

                #region Hostel room.facilities
                new Permission (HostelRoomFacilitiesCreate,   Create, $"room.facilities.{Create.ToLower()}",  HostelRoomFacilitiesGroup, HostelManagement),
                new Permission (HostelRoomFacilitiesUpdate,   Update, $"room.facilities.{Update.ToLower()}",  HostelRoomFacilitiesGroup, HostelManagement),
                new Permission (HostelRoomFacilitiesList,     List,   $"room.facilities.{List.ToLower()}",    HostelRoomFacilitiesGroup, HostelManagement),
                new Permission (HostelRoomFacilitiesDelete,   Delete, $"room.facilities.{Delete.ToLower()}",  HostelRoomFacilitiesGroup, HostelManagement),
                new Permission (HostelRoomFacilitiesManage,   Manage, $"room.facilities.{Manage.ToLower()}",  HostelRoomFacilitiesGroup, HostelManagement),
                #endregion

                #region Traingin course
                new Permission (TrainingCourseCreate,   Create, $"course.{Create.ToLower()}",  TrainingCourseGroup, TrainingManagement),
                new Permission (TrainingCourseUpdate,   Update, $"course.{Update.ToLower()}",  TrainingCourseGroup, TrainingManagement),
                new Permission (TrainingCourseList,     List,   $"course.{List.ToLower()}",    TrainingCourseGroup, TrainingManagement),
                new Permission (TrainingCourseDelete,   Delete, $"course.{Delete.ToLower()}",  TrainingCourseGroup, TrainingManagement),
                new Permission (TrainingCourseManage,   Manage, $"course.{Manage.ToLower()}",  TrainingCourseGroup, TrainingManagement),
                #endregion

                #region Traingin module
                new Permission (TrainingModuleCreate,   Create, $"module.{Create.ToLower()}",  TrainingModuleGroup, TrainingManagement),
                new Permission (TrainingModuleUpdate,   Update, $"module.{Update.ToLower()}",  TrainingModuleGroup, TrainingManagement),
                new Permission (TrainingModuleList,     List,   $"module.{List.ToLower()}",    TrainingModuleGroup, TrainingManagement),
                new Permission (TrainingModuleDelete,   Delete, $"module.{Delete.ToLower()}",  TrainingModuleGroup, TrainingManagement),
                new Permission (TrainingModuleManage,   Manage, $"module.{Manage.ToLower()}",  TrainingModuleGroup, TrainingManagement),
                #endregion

                #region Traingin topic
                new Permission (TrainingTopicCreate,   Create, $"topic.{Create.ToLower()}",  TrainingTopicGroup, TrainingManagement),
                new Permission (TrainingTopicUpdate,   Update, $"topic.{Update.ToLower()}",  TrainingTopicGroup, TrainingManagement),
                new Permission (TrainingTopicList,     List,   $"topic.{List.ToLower()}",    TrainingTopicGroup, TrainingManagement),
                new Permission (TrainingTopicDelete,   Delete, $"topic.{Delete.ToLower()}",  TrainingTopicGroup, TrainingManagement),
                new Permission (TrainingTopicManage,   Manage, $"topic.{Manage.ToLower()}",  TrainingTopicGroup, TrainingManagement),
                #endregion

                #region Traingin course.category
                new Permission (TrainingCourseCategoryCreate,   Create, $"course.category.{Create.ToLower()}",  TrainingCourseCategoryGroup, TrainingManagement),
                new Permission (TrainingCourseCategoryUpdate,   Update, $"course.category.{Update.ToLower()}",  TrainingCourseCategoryGroup, TrainingManagement),
                new Permission (TrainingCourseCategoryList,     List,   $"course.category.{List.ToLower()}",    TrainingCourseCategoryGroup, TrainingManagement),
                new Permission (TrainingCourseCategoryDelete,   Delete, $"course.category.{Delete.ToLower()}",  TrainingCourseCategoryGroup, TrainingManagement),
                new Permission (TrainingCourseCategoryManage,   Manage, $"course.category.{Manage.ToLower()}",  TrainingCourseCategoryGroup, TrainingManagement),
                #endregion

                #region Traingin method
                new Permission (TrainingMethodCreate,   Create, $"method.{Create.ToLower()}",  TrainingMethodGroup, TrainingManagement),
                new Permission (TrainingMethodUpdate,   Update, $"method.{Update.ToLower()}",  TrainingMethodGroup, TrainingManagement),
                new Permission (TrainingMethodList,     List,   $"method.{List.ToLower()}",    TrainingMethodGroup, TrainingManagement),
                new Permission (TrainingMethodDelete,   Delete, $"method.{Delete.ToLower()}",  TrainingMethodGroup, TrainingManagement),
                new Permission (TrainingMethodManage,   Manage, $"method.{Manage.ToLower()}",  TrainingMethodGroup, TrainingManagement),
                #endregion

                #region Traingin evaluation.method
                new Permission (TrainingEvaluationMethodCreate,   Create, $"evaluation.method.{Create.ToLower()}",  TrainingEvaluationMethodGroup, TrainingManagement),
                new Permission (TrainingEvaluationMethodUpdate,   Update, $"evaluation.method.{Update.ToLower()}",  TrainingEvaluationMethodGroup, TrainingManagement),
                new Permission (TrainingEvaluationMethodList,     List,   $"evaluation.method.{List.ToLower()}",    TrainingEvaluationMethodGroup, TrainingManagement),
                new Permission (TrainingEvaluationMethodDelete,   Delete, $"evaluation.method.{Delete.ToLower()}",  TrainingEvaluationMethodGroup, TrainingManagement),
                new Permission (TrainingEvaluationMethodManage,   Manage, $"evaluation.method.{Manage.ToLower()}",  TrainingEvaluationMethodGroup, TrainingManagement),
                #endregion

                #region Traingin grade
                new Permission (TrainingGradeCreate,   Create, $"grade.{Create.ToLower()}",  TrainingGradeGroup, TrainingManagement),
                new Permission (TrainingGradeUpdate,   Update, $"grade.{Update.ToLower()}",  TrainingGradeGroup, TrainingManagement),
                new Permission (TrainingGradeList,     List,   $"grade.{List.ToLower()}",    TrainingGradeGroup, TrainingManagement),
                new Permission (TrainingGradeDelete,   Delete, $"grade.{Delete.ToLower()}",  TrainingGradeGroup, TrainingManagement),
                new Permission (TrainingGradeManage,   Manage, $"grade.{Manage.ToLower()}",  TrainingGradeGroup, TrainingManagement),
                #endregion

                #region Traingin expertise
                new Permission (TrainingExpertiseCreate,   Create, $"expertise.{Create.ToLower()}",  TrainingExpertiseGroup, TrainingManagement),
                new Permission (TrainingExpertiseUpdate,   Update, $"expertise.{Update.ToLower()}",  TrainingExpertiseGroup, TrainingManagement),
                new Permission (TrainingExpertiseList,     List,   $"expertise.{List.ToLower()}",    TrainingExpertiseGroup, TrainingManagement),
                new Permission (TrainingExpertiseDelete,   Delete, $"expertise.{Delete.ToLower()}",  TrainingExpertiseGroup, TrainingManagement),
                new Permission (TrainingExpertiseManage,   Manage, $"expertise.{Manage.ToLower()}",  TrainingExpertiseGroup, TrainingManagement),
                #endregion

                #region Traingin resource.person
                new Permission (TrainingResourcePersonCreate,   Create, $"resource.person.{Create.ToLower()}",  TrainingResourcePersonGroup, TrainingManagement),
                new Permission (TrainingResourcePersonUpdate,   Update, $"resource.person.{Update.ToLower()}",  TrainingResourcePersonGroup, TrainingManagement),
                new Permission (TrainingResourcePersonList,     List,   $"resource.person.{List.ToLower()}",    TrainingResourcePersonGroup, TrainingManagement),
                new Permission (TrainingResourcePersonDelete,   Delete, $"resource.person.{Delete.ToLower()}",  TrainingResourcePersonGroup, TrainingManagement),
                new Permission (TrainingResourcePersonManage,   Manage, $"resource.person.{Manage.ToLower()}",  TrainingResourcePersonGroup, TrainingManagement),
                #endregion

                #region Traingin schedule
                new Permission (TrainingScheduleCreate,   Create, $"schedule.{Create.ToLower()}",  TrainingScheduleGroup, TrainingManagement),
                new Permission (TrainingScheduleUpdate,   Update, $"schedule.{Update.ToLower()}",  TrainingScheduleGroup, TrainingManagement),
                new Permission (TrainingScheduleList,     List,   $"schedule.{List.ToLower()}",    TrainingScheduleGroup, TrainingManagement),
                new Permission (TrainingScheduleDelete,   Delete, $"schedule.{Delete.ToLower()}",  TrainingScheduleGroup, TrainingManagement),
                new Permission (TrainingScheduleManage,   Manage, $"schedule.{Manage.ToLower()}",  TrainingScheduleGroup, TrainingManagement),
                #endregion

                #region Traingin batch
                new Permission (TrainingBatchCreate,   Create, $"batch.{Create.ToLower()}",  TrainingBatchGroup, TrainingManagement),
                new Permission (TrainingBatchUpdate,   Update, $"batch.{Update.ToLower()}",  TrainingBatchGroup, TrainingManagement),
                new Permission (TrainingBatchList,     List,   $"batch.{List.ToLower()}",    TrainingBatchGroup, TrainingManagement),
                new Permission (TrainingBatchDelete,   Delete, $"batch.{Delete.ToLower()}",  TrainingBatchGroup, TrainingManagement),
                new Permission (TrainingBatchManage,   Manage, $"batch.{Manage.ToLower()}",  TrainingBatchGroup, TrainingManagement),
                new Permission (MyExamManage,          MyExam, $"myexam.{Manage.ToLower()}", TrainingBatchGroup, TrainingManagement),
                #endregion

                #region Traingin batch.allocation
                new Permission (TrainingBatchAllocationCreate,   Create, $"batch.allocation.{Create.ToLower()}",  TrainingBatchAllocationGroup, TrainingManagement),
                new Permission (TrainingBatchAllocationUpdate,   Update, $"batch.allocation.{Update.ToLower()}",  TrainingBatchAllocationGroup, TrainingManagement),
                new Permission (TrainingBatchAllocationList,     List,   $"batch.allocation.{List.ToLower()}",    TrainingBatchAllocationGroup, TrainingManagement),
                new Permission (TrainingBatchAllocationDelete,   Delete, $"batch.allocation.{Delete.ToLower()}",  TrainingBatchAllocationGroup, TrainingManagement),
                new Permission (TrainingBatchAllocationManage,   Manage, $"batch.allocation.{Manage.ToLower()}",  TrainingBatchAllocationGroup, TrainingManagement),
                #endregion

                #region Traingin question
                new Permission (TrainingQuestionCreate,   Create, $"question.{Create.ToLower()}",  TrainingQuestionGroup, TrainingManagement),
                new Permission (TrainingQuestionUpdate,   Update, $"question.{Update.ToLower()}",  TrainingQuestionGroup, TrainingManagement),
                new Permission (TrainingQuestionList,     List,   $"question.{List.ToLower()}",    TrainingQuestionGroup, TrainingManagement),
                new Permission (TrainingQuestionDelete,   Delete, $"question.{Delete.ToLower()}",  TrainingQuestionGroup, TrainingManagement),
                new Permission (TrainingQuestionManage,   Manage, $"question.{Manage.ToLower()}",  TrainingQuestionGroup, TrainingManagement),
                #endregion

                #region Traingin honorarium.head
                new Permission (TrainingHonorariumHeadCreate,   Create, $"honorarium.head.{Create.ToLower()}",  TrainingHonorariumHeadGroup, TrainingManagement),
                new Permission (TrainingHonorariumHeadUpdate,   Update, $"honorarium.head.{Update.ToLower()}",  TrainingHonorariumHeadGroup, TrainingManagement),
                new Permission (TrainingHonorariumHeadList,     List,   $"honorarium.head.{List.ToLower()}",    TrainingHonorariumHeadGroup, TrainingManagement),
                new Permission (TrainingHonorariumHeadDelete,   Delete, $"honorarium.head.{Delete.ToLower()}",  TrainingHonorariumHeadGroup, TrainingManagement),
                new Permission (TrainingHonorariumHeadManage,   Manage, $"honorarium.head.{Manage.ToLower()}",  TrainingHonorariumHeadGroup, TrainingManagement),
                #endregion
            };
        }
    }
}
