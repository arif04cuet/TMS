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
                new PermissionGroup(OfficeGroup, "Office"),
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
                new PermissionGroup(BookReservationGroup, "Book Reservation"),
                
                //asset
                new PermissionGroup(AssetGroup, "Asset"),
                new PermissionGroup(MaintenanceGroup, "Maintenance"),
                new PermissionGroup(LicenseGroup, "License"),
                new PermissionGroup(ConsumableGroup, "Consumable"),
                new PermissionGroup(SettingGroup, "Setting"),
                new PermissionGroup(AssetReportGroup, "Report"),
                new PermissionGroup(AssetRequisitionGroup, "Requisition"),
                
                new PermissionGroup(AssetSettingModelGroup, "Asset Setting Model"),
                new PermissionGroup(AssetSettingItemCodeGroup, "Asset Setting Item Code"),
                new PermissionGroup(AssetSettingSupplierGroup, "Asset Setting Supplier"),
                new PermissionGroup(AssetSettingDepreciationGroup, "Asset Setting Depreciation"),
                new PermissionGroup(AssetSettingManufacturerGroup, "Asset Setting Manufacturer"),
                new PermissionGroup(AssetSettingStatusGroup, "Asset Setting Status"),
                new PermissionGroup(AssetSettingCategoryGroup, "Asset Setting Category"),

                //CMS
                new PermissionGroup(ContentCategoryGroup, "Contents Category"),
                new PermissionGroup(ContentsGroup, "Contents"),
                new PermissionGroup(ContentFaqGroup, "Contents Faq"),
                new PermissionGroup(ContentBannerGroup, "Contents Banner"),

                //Hostel
                new PermissionGroup(HostelAllocationGroup, "Hostel Allocation"),
                new PermissionGroup(HostelHostelGroup, "Hostels"),
                new PermissionGroup(HostelBuildingGroup, "Building"),
                new PermissionGroup(HostelRoomGroup, "Room"),
                new PermissionGroup(HostelBedGroup, "Bed"),
                new PermissionGroup(HostelRoomTypeGroup, "Room Type"),
                new PermissionGroup(HostelRoomFacilitiesGroup, "Room facilities"),

                //Training
                new PermissionGroup(TrainingCourseGroup, "Course"),
                new PermissionGroup(TrainingModuleGroup, "Module"),
                new PermissionGroup(TrainingTopicGroup, "Session"),
                new PermissionGroup(TrainingCourseCategoryGroup, "Course Category"),
                new PermissionGroup(TrainingMethodGroup, "Training Method"),
                new PermissionGroup(TrainingEvaluationMethodGroup, "Evaluation Method"),
                new PermissionGroup(TrainingGradeGroup, "Grade"),
                new PermissionGroup(TrainingExpertiseGroup, "Exertise"),
                new PermissionGroup(TrainingResourcePersonGroup, "Resource Person"),
                new PermissionGroup(TrainingScheduleGroup, "Course Schedule"),
                new PermissionGroup(TrainingBatchGroup, "Batch Schedule"),
                new PermissionGroup(TrainingBatchAllocationGroup, "Participant Approval"),
                new PermissionGroup(TrainingQuestionGroup, "Question"),
                new PermissionGroup(TrainingHonorariumHeadGroup, "Honorarium Head"),

                //Others
                new PermissionGroup(OthersGroup, "Others")


            };
        }
    }
}
