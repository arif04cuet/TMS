import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [

      {
        path: '',
        loadChildren: () => import('../dashboard/dashboard.module').then(x => x.DashboardModule),
        data: {
          name: 'dashboard',
          breadcrumb: {
            icon: 'team',
            title: 'dashboard'
          }
        }
      },

      {
        path: 'cms/faq',
        loadChildren: () => import('../cms/faq/list/faq-list.module').then(x => x.CmsFaqListModule),
        data: {
          name: 'cms_faq',
          breadcrumb: {
            icon: 'team',
            title: 'cms.faq',
            module: "cms"
          },
          permissions: ['content.faq.manage', 'content.faq.list']
        }
      },

      {
        path: 'cms/banners',
        loadChildren: () => import('../cms/banner/list/banner-list.module').then(x => x.BannerListModule),
        data: {
          name: 'cms_banners',
          breadcrumb: {
            icon: 'team',
            title: 'cms.banner',
            module: "cms"
          },
          permissions: ['content.banner.manage', 'content.banner.list']
        }
      },

      {
        path: 'cms/contents',
        loadChildren: () => import('../cms/content/list/content-list.module').then(x => x.CmsContentListModule),
        data: {
          name: 'cms_contents',
          breadcrumb: {
            icon: 'team',
            title: 'cms.content',
            module: "cms"
          },
          permissions: ['content.manage', 'content.list']
        }
      },

      {
        path: 'cms/categories',
        loadChildren: () => import('../cms/category/list/category-list.module').then(x => x.CmsCategoryListModule),
        data: {
          name: 'cms_categories',
          breadcrumb: {
            icon: 'team',
            title: 'cms.category',
            module: "cms"
          },
          permissions: ['content.category.manage', 'content.category.list']
        }
      },

      {
        path: 'users',
        loadChildren: () => import('../user/user/list/user-list.module').then(x => x.UserListModule),
        data: {
          name: 'user_list',
          breadcrumb: {
            icon: 'team',
            title: 'users',
            module: "user.management"
          },
          permissions: ['user.manage', 'user.list']
        }
      },
      {
        path: 'roles',
        loadChildren: () => import('../user/role/list/role-list.module').then(x => x.RoleListModule),
        data: {
          name: 'role_list',
          breadcrumb: {
            icon: 'safety',
            title: 'roles',
            module: "user.management"
          },
          permissions: ['role.manage', 'role.list']
        }
      },
      {
        path: 'offices',
        loadChildren: () => import('../user/office/list/office-list.module').then(x => x.OfficeListModule),
        data: {
          name: 'office_list',
          breadcrumb: {
            icon: 'safety',
            title: 'offices',
            module: "user.management"
          },
          permissions: ['office.manage', 'office.list']
        }
      },
      {
        path: 'designations',
        loadChildren: () => import('../user/designation/list/designation-list.module').then(x => x.DesignationListModule),
        data: {
          name: 'designation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'designations',
            module: "user.management"
          },
          permissions: ['designation.manage', 'designation.list']
        }
      },
      {
        path: 'departments',
        loadChildren: () => import('../user/department/list/department-list.module').then(x => x.DepartmentListModule),
        data: {
          name: 'department_list',
          breadcrumb: {
            icon: 'safety',
            title: 'departments',
            module: "user.management"
          },
          permissions: ['department.manage', 'department.list']
        }
      },
      {
        path: 'profile',
        loadChildren: () => import('../user/profile/view/profile-view.module').then(x => x.ProfileViewModule),
        data: {
          name: 'profile_view',
          breadcrumb: {
            icon: 'safety',
            title: 'profile'
          },
          permissions: ['profile.manage', 'profile.view']
        }
      },
      {
        path: 'libraries',
        loadChildren: () => import('../library/library/list/library-list.module').then(x => x.LibraryListModule),
        data: {
          name: 'library_list',
          breadcrumb: {
            icon: 'safety',
            title: 'libraries',
            module: "library.management"
          },
          permissions: ['library.manage', 'library.list']
        }
      },
      {
        path: 'library/members',
        loadChildren: () => import('../library/member/list/member-list.module').then(x => x.MemberListModule),
        data: {
          name: 'library_member_list',
          breadcrumb: {
            icon: 'safety',
            title: 'members',
            module: "library.management"
          },
          permissions: ['library.member.manage', 'library.member.list']
        }
      },
      {
        path: 'library/members/requests',
        loadChildren: () => import('../library/member/request-list/request-list.module').then(x => x.MemberRequestListModule),
        data: {
          name: 'library_members_requests_list',
          breadcrumb: {
            icon: 'safety',
            title: 'members',
            module: "library.management"
          },
          permissions: ['library.member.request.manage', 'library.member.request.list']
        }
      },
      {
        path: 'library/cards',
        loadChildren: () => import('../library/card/list/card-list.module').then(x => x.CardListModule),
        data: {
          name: 'library_card_list',
          breadcrumb: {
            icon: 'safety',
            title: 'cards',
            module: "library.management"
          },
          permissions: ['card.manage', 'card.list']
        }
      },
      {
        path: 'library/books',
        loadChildren: () => import('../library/book/list/book-list.module').then(x => x.BookListModule),
        data: {
          name: 'book_list',
          breadcrumb: {
            icon: 'safety',
            title: 'books',
            module: "library.management"
          },
          permissions: ['book.catalog.manage', 'book.catalog.list']
        }
      },
      {
        path: 'library/books/items',
        loadChildren: () => import('../library/book-item/list/book-item-list.module').then(x => x.BookItemListModule),
        data: {
          name: 'book_item_list',
          breadcrumb: {
            icon: 'safety',
            title: 'books',
            module: "library.management"
          },
          permissions: ['book.manage', 'book.list']
        }
      },
      {
        path: 'library/racks',
        loadChildren: () => import('../library/rack/list/rack-list.module').then(x => x.RackListModule),
        data: {
          name: 'rack_list',
          breadcrumb: {
            icon: 'safety',
            title: 'racks',
            module: "library.management"
          },
          permissions: ['rack.manage', 'rack.list']
        }
      },
      {
        path: 'library/authors',
        loadChildren: () => import('../library/author/list/author-list.module').then(x => x.AuthorListModule),
        data: {
          name: 'author_list',
          breadcrumb: {
            icon: 'safety',
            title: 'authors',
            module: "library.management"
          },
          permissions: ['author.manage', 'author.list']
        }
      },
      {
        path: 'library/publishers',
        loadChildren: () => import('../library/publisher/list/publisher-list.module').then(x => x.PublisherListModule),
        data: {
          name: 'publisher_list',
          breadcrumb: {
            icon: 'safety',
            title: 'publishers',
            module: "library.management"
          },
          permissions: ['publisher.manage', 'publisher.list']
        }
      },
      {
        path: 'library/categories',
        loadChildren: () => import('../library/subject/list/subject-list.module').then(x => x.SubjectListModule),
        data: {
          name: 'category_list',
          breadcrumb: {
            icon: 'safety',
            title: 'categories',
            module: "library.management"
          },
          permissions: ['book.category.manage', 'book.category.list']
        }
      },
      {
        path: 'library/reports/issues',
        loadChildren: () => import('../library/reports/issue/issue-list.module').then(x => x.IssueListModule),
        data: {
          name: 'issue_list',
          breadcrumb: {
            icon: 'safety',
            title: 'issues',
            module: "library.management"
          },
          permissions: ['library.report.issue']
        }
      },
      {
        path: 'library/fines',
        loadChildren: () => import('../library/fine/list/fine-list.module').then(x => x.FineListModule),
        data: {
          name: 'fine_list',
          breadcrumb: {
            icon: 'safety',
            title: 'fines',
            module: "library.management"
          },
          permissions: ['library.report.fine']
        }
      },
      {
        path: 'library/reports/book-entry',
        loadChildren: () => import('../library/reports/entry/entry-list.module').then(x => x.EntryListModule),
        data: {
          name: 'library_book_entry',
          breadcrumb: {
            icon: 'safety',
            title: 'book.entry',
            module: "library.management"
          },
          permissions: ['library.report.book.entry']
        }
      },
      {
        path: 'library/reports/library-at-a-glance',
        loadChildren: () => import('../library/reports/glance/glance-list.module').then(x => x.GlanceListModule),
        data: {
          name: 'library_at_a_glance',
          breadcrumb: {
            icon: 'safety',
            title: 'library.at.a.glance',
            module: "library.management"
          },
          permissions: ['library.report.at.a.glance']
        }
      },
      {
        path: 'library/reports/lost-books',
        loadChildren: () => import('../library/reports/lost/lost-list.module').then(x => x.LostListModule),
        data: {
          name: 'library_lost_books',
          breadcrumb: {
            icon: 'safety',
            title: 'lost.books',
            module: "library.management"
          },
          permissions: ['library.report.lost.books']
        }
      },
      {
        path: 'library/reports/new-books',
        loadChildren: () => import('../library/reports/new/new-list.module').then(x => x.NewListModule),
        data: {
          name: 'library_new_books',
          breadcrumb: {
            icon: 'safety',
            title: 'new.books',
            module: "library.management"
          },
          permissions: ['library.report.new.books']
        }
      },
      {
        path: 'asset',
        loadChildren: () => import('../asset/asset/list/asset-list.module').then(x => x.AssetListModule),
        data: {
          name: 'asset_list',
          breadcrumb: {
            icon: 'safety',
            title: 'assets',
            module: "asset.management"
          },
          permissions: ['asset.manage', 'asset.list']
        }
      },
      {
        path: 'asset/my-requisitions',
        loadChildren: () => import('../asset/asset/requisition/list/requisition-list.module').then(x => x.RequisitionListModule),
        data: {
          name: 'requisition_list',
          breadcrumb: {
            icon: 'safety',
            title: 'requisitions',
            module: "asset.management"
          },
          permissions: ['requisition.manage', 'requisition.list']
        }
      },
      {
        path: 'asset/maintenances',
        loadChildren: () => import('../asset/asset/view/maintenance/list/asset-maintenance-list.module').then(x => x.AssetMaintenanceListModule),
        data: {
          name: 'maintenance_list',
          breadcrumb: {
            icon: 'plus',
            title: 'maintenances',
            module: "asset.management"
          },
          permissions: ['maintenance.manage', 'maintenance.list']
        }
      },
      {
        path: 'asset/models',
        loadChildren: () => import('../asset/asset-model/list/asset-model-list.module').then(x => x.AssetModelListModule),
        data: {
          name: 'asset_model_list',
          breadcrumb: {
            icon: 'safety',
            title: 'asset.models',
            module: "asset.management"
          },
          permissions: ['asset.model.manage', 'asset.model.list']
        }
      },
      {
        path: 'asset/audit',
        loadChildren: () => import('../asset/asset/audit/add/asset-audit-add.module').then(x => x.AssetAuditAddModule),
        data: {
          name: 'asset_audit_add',
          breadcrumb: {
            icon: 'safety',
            title: 'audit',
            module: "asset.management"
          },
          permissions: ['asset.audit.create']
        }
      },
      {
        path: 'asset/itemcodes/consumable',
        loadChildren: () => import('../asset/itemcode/list/itemcode-list.module').then(x => x.ItemCodeListModule),
        data: {
          name: 'asset_itemcode_list',
          parentId: 2,
          breadcrumb: {
            icon: 'safety',
            title: 'asset.itemcode',
            module: "asset.management"
          },
          permissions: ['item.code.manage', 'item.code.list']
        }
      },
      // {
      //   path: 'asset/itemcodes/license',
      //   loadChildren: () => import('../asset/itemcode/list/itemcode-list.module').then(x => x.ItemCodeListModule),
      //   data: {
      //     name: 'asset_itemcode_list',
      //     parentId: 3,
      //     breadcrumb: {
      //       icon: 'safety',
      //       title: 'asset.itemcode'
      //     }
      //   }
      // },
      // {
      //   path: 'asset/accessories',
      //   loadChildren: () => import('../asset/accessory/list/accessory-list.module').then(x => x.AccessoryListModule),
      //   data: {
      //     name: 'accessory_list',
      //     breadcrumb: {
      //       icon: 'safety',
      //       title: 'accessory'
      //     }
      //   }
      // },
      {
        path: 'asset/consumables',
        loadChildren: () => import('../asset/consumable/list/consumable-list.module').then(x => x.ConsumableListModule),
        data: {
          name: 'consumable_list',
          breadcrumb: {
            icon: 'safety',
            title: 'consumable',
            module: "asset.management"
          },
          permissions: ['consumable.manage', 'consumable.list']
        }
      },
      // {
      //   path: 'asset/components',
      //   loadChildren: () => import('../asset/component/list/component-list.module').then(x => x.ComponentListModule),
      //   data: {
      //     name: 'component_list',
      //     breadcrumb: {
      //       icon: 'safety',
      //       title: 'component'
      //     }
      //   }
      // },
      {
        path: 'asset/suppliers',
        loadChildren: () => import('../asset/supplier/list/supplier-list.module').then(x => x.SupplierListModule),
        data: {
          name: 'supplier_list',
          breadcrumb: {
            icon: 'safety',
            title: 'supplier',
            module: "asset.management"
          },
          permissions: ['supplier.manage', 'supplier.list']
        }
      },
      {
        path: 'asset/depreciations',
        loadChildren: () => import('../asset/depreciation/list/depreciation-list.module').then(x => x.DepreciationListModule),
        data: {
          name: 'depreciation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'depreciation',
            module: "asset.management"
          },
          permissions: ['depreciation.manage', 'depreciation.list']
        }
      },

      {
        path: 'asset/manufacturers',
        loadChildren: () => import('../asset/manufacturer/list/manufacturer-list.module').then(x => x.ManufacturerListModule),
        data: {
          name: 'manufacturer_list',
          breadcrumb: {
            icon: 'safety',
            title: 'manufacturer',
            module: "asset.management"
          },
          permissions: ['manufacturer.manage', 'manufacturer.list']
        }
      },
      {
        path: 'asset/statuses',
        loadChildren: () => import('../asset/status/list/status-list.module').then(x => x.StatusListModule),
        data: {
          name: 'status_list',
          breadcrumb: {
            icon: 'safety',
            title: 'status',
            module: "asset.management"
          },
          permissions: ['asset.status.manage', 'asset.status.list']
        }
      },
      {
        path: 'asset/categories',
        loadChildren: () => import('../asset/category/list/category-list.module').then(x => x.CategoryListModule),
        data: {
          name: 'category_list',
          breadcrumb: {
            icon: 'safety',
            title: 'category',
            module: "asset.management"
          },
          permissions: ['asset.category.manage', 'asset.category.list']
        }
      },
      {
        path: 'asset/licenses',
        loadChildren: () => import('../asset/license/list/license-list.module').then(x => x.LicenseListModule),
        data: {
          name: 'license_list',
          breadcrumb: {
            icon: 'safety',
            title: 'license',
            module: "asset.management"
          },
          permissions: ['license.manage', 'license.list']
        }
      },
      {
        path: 'asset/reports/activity-log',
        loadChildren: () => import('../asset/reports/activity-log/asset-activity-log.module').then(x => x.AssetActivityLogModule),
        data: {
          name: 'asset_activity_log',
          breadcrumb: {
            icon: 'safety',
            title: 'activity.log',
            module: "asset.management"
          },
          permissions: ['report.activity.log']
        }
      },
      {
        path: 'asset/reports/audit-log',
        loadChildren: () => import('../asset/reports/audit-log/asset-audit-log.module').then(x => x.AssetAuditLogModule),
        data: {
          name: 'asset_audit_log',
          breadcrumb: {
            icon: 'safety',
            title: 'audit.log',
            module: "asset.management"
          },
          permissions: ['report.audit.log']
        }
      },
      {
        path: 'asset/reports/depreciation',
        loadChildren: () => import('../asset/reports/depreciation/depreciation-report.module').then(x => x.DepreciationReportModule),
        data: {
          name: 'asset_depreciation_report',
          breadcrumb: {
            icon: 'safety',
            title: 'depreciation.report',
            module: "asset.management"
          },
          permissions: ['report.depreciation']
        }
      },
      {
        path: 'asset/reports/depreciation/:assetId/schedules',
        loadChildren: () => import('../asset/reports/depreciation-schedule/depreciation-schedule-report.module').then(x => x.DepreciationScheduleReportModule),
        data: {
          name: 'asset_depreciation_report',
          breadcrumb: {
            icon: 'safety',
            title: 'depreciation.report',
            module: "asset.management"
          },
          permissions: ['report.depreciation']
        }
      },
      {
        path: 'asset/reports/license',
        loadChildren: () => import('../asset/reports/license/license-report.module').then(x => x.LicenseReportModule),
        data: {
          name: 'asset_license_report',
          breadcrumb: {
            icon: 'safety',
            title: 'license.report',
            module: "asset.management"
          },
          permissions: ['report.license']
        }
      },
      {
        path: 'asset/reports/maintenance',
        loadChildren: () => import('../asset/reports/maintenance/maintenance-report.module').then(x => x.MaintenanceReportModule),
        data: {
          name: 'asset_maintenance_report',
          breadcrumb: {
            icon: 'safety',
            title: 'maintenance.report',
            module: "asset.management"
          },
          permissions: ['report.maintenance']
        }
      },
      {
        path: 'asset/reports/asset',
        loadChildren: () => import('../asset/reports/asset/asset-report.module').then(x => x.AssetReportModule),
        data: {
          name: 'asset_asset_report',
          breadcrumb: {
            icon: 'safety',
            title: 'asset.report',
            module: "asset.management"
          },
          permissions: ['report.asset']
        }
      },
      {
        path: 'hostels/allocations',
        loadChildren: () => import('../hostel/allocation/list/allocation-list.module').then(x => x.AllocationListModule),
        data: {
          name: 'allocation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'allocations',
            module: "hostel.management"
          },
          permissions: ['allocation.manage', 'allocation.list']
        }
      },
      {
        path: 'hostels',
        loadChildren: () => import('../hostel/hostel/list/hostel-list.module').then(x => x.HostelListModule),
        data: {
          name: 'hostel_list',
          breadcrumb: {
            icon: 'safety',
            title: 'hostels',
            module: "hostel.management"
          },
          permissions: ['hostel.manage', 'hostel.list']
        }
      },
      {
        path: 'hostels/buildings',
        loadChildren: () => import('../hostel/building/list/building-list.module').then(x => x.BuildingListModule),
        data: {
          name: 'building_list',
          breadcrumb: {
            icon: 'safety',
            title: 'buildings',
            module: "hostel.management"
          },
          permissions: ['building.manage', 'building.list']
        }
      },
      {
        path: 'hostels/facilities',
        loadChildren: () => import('../hostel/facilities/list/facilities-list.module').then(x => x.FacilitiesListModule),
        data: {
          name: 'facilities_list',
          breadcrumb: {
            icon: 'safety',
            title: 'facilities',
            module: "hostel.management"
          },
          permissions: ['room.facilities.manage', 'room.facilities.list']
        }
      },
      {
        path: 'hostels/rooms',
        loadChildren: () => import('../hostel/room/list/room-list.module').then(x => x.RoomListModule),
        data: {
          name: 'room_list',
          breadcrumb: {
            icon: 'safety',
            title: 'rooms',
            module: "hostel.management"
          },
          permissions: ['room.manage', 'room.list']
        }
      },
      {
        path: 'hostels/beds',
        loadChildren: () => import('../hostel/bed/list/bed-list.module').then(x => x.BedListModule),
        data: {
          name: 'bed_list',
          breadcrumb: {
            icon: 'safety',
            title: 'beds',
            module: "hostel.management"
          },
          permissions: ['bed.manage', 'bed.list']
        }
      },
      {
        path: 'courses/grades',
        loadChildren: () => import('../course/grade/list/grade-list.module').then(x => x.GradeListModule),
        data: {
          name: 'grade_list',
          breadcrumb: {
            icon: 'safety',
            title: 'grades',
            module: "course.management"
          },
          permissions: ['grade.manage', 'grade.list']
        }
      },
      {
        path: 'courses/evaluation-methods',
        loadChildren: () => import('../course/evaluation-method/list/evaluation-method-list.module').then(x => x.EvaluationMethodListModule),
        data: {
          name: 'evaluation_method_list',
          breadcrumb: {
            icon: 'safety',
            title: 'evaluation.methods',
            module: "course.management"
          },
          permissions: ['evaluation.method.manage', 'evaluation.method.list']
        }
      },
      {
        path: 'courses/methods',
        loadChildren: () => import('../course/method/list/method-list.module').then(x => x.MethodListModule),
        data: {
          name: 'course_method_list',
          breadcrumb: {
            icon: 'safety',
            title: 'course.methods',
            module: "course.management"
          },
          permissions: ['method.manage', 'method.list']
        }
      },
      {
        path: 'courses/categories',
        loadChildren: () => import('../course/category/list/category-list.module').then(x => x.CategoryListModule),
        data: {
          name: 'course_category_list',
          breadcrumb: {
            icon: 'safety',
            title: 'course.categories',
            module: "course.management"
          },
          permissions: ['course.category.manage', 'course.category.list']
        }
      },
      {
        path: 'courses/topics',
        loadChildren: () => import('../course/topic/list/topic-list.module').then(x => x.TopicListModule),
        data: {
          name: 'course_topic_list',
          breadcrumb: {
            icon: 'safety',
            title: 'topics',
            module: "course.management"
          },
          permissions: ['topic.manage', 'topic.list']
        }
      },
      {
        path: 'courses/modules',
        loadChildren: () => import('../course/module/list/module-list.module').then(x => x.ModuleListModule),
        data: {
          name: 'course_module_list',
          breadcrumb: {
            icon: 'safety',
            title: 'modules',
            module: "course.management"
          },
          permissions: ['module.manage', 'module.list']
        }
      },
      {
        path: 'courses',
        loadChildren: () => import('../course/course/list/course-list.module').then(x => x.CourseListModule),
        data: {
          name: 'course_list',
          breadcrumb: {
            icon: 'safety',
            title: 'courses',
            module: "course.management"
          },
          permissions: ['course.manage', 'course.list']
        }
      },
      {
        path: 'courses/resource-persons',
        loadChildren: () => import('../course/resource-person/list/resource-person-list.module').then(x => x.ResourcePersonListModule),
        data: {
          name: 'resource_persons_list',
          breadcrumb: {
            icon: 'safety',
            title: 'resource.persons',
            module: "course.management"
          },
          permissions: ['resource.person.manage', 'resource.person.list']
        }
      },
      {
        path: 'courses/expertise',
        loadChildren: () => import('../course/expertise/list/expertise-list.module').then(x => x.ExpertiseListModule),
        data: {
          name: 'expertise_list',
          breadcrumb: {
            icon: 'safety',
            title: 'expertise',
            module: "course.management"
          },
          permissions: ['expertise.manage', 'expertise.list']
        }
      },
      // Budget and schedule
      {
        path: 'trainings/honorarium-heads',
        loadChildren: () => import('../budget-and-schedule/honorarium-head/list/honorarium-head-list.module').then(x => x.HonorariumHeadListModule),
        data: {
          name: 'honorarium_head_list',
          breadcrumb: {
            icon: 'safety',
            title: 'honorarium.heads',
            module: "course.management"
          },
          permissions: ['honorarium.head.manage', 'honorarium.head.list']
        }
      },
      {
        path: 'trainings/course-schedules',
        loadChildren: () => import('../budget-and-schedule/course-schedule/list/course-schedule-list.module').then(x => x.CourseScheduleListModule),
        data: {
          name: 'course_schedule_list',
          breadcrumb: {
            icon: 'safety',
            title: 'course.schedules',
            module: "budget.and.schedule"
          },
          permissions: ['schedule.manage', 'schedule.list']
        }
      },
      {
        path: 'trainings/batch-schedules',
        loadChildren: () => import('../budget-and-schedule/batch-schedule/list/batch-schedule-list.module').then(x => x.BatchScheduleListModule),
        data: {
          name: 'batch_schedule_list',
          breadcrumb: {
            icon: 'safety',
            title: 'batch.schedules',
            module: "budget.and.schedule"
          },
          permissions: ['batch.manage', 'batch.list']
        }
      },
      {
        path: 'trainings/batch-schedules/allocations',
        loadChildren: () => import('../budget-and-schedule/batch-schedule/allocation/list/batch-schedule-allocation-list.module').then(x => x.BatchScheduleAllocationListModule),
        data: {
          name: 'batch_schedule_allocation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'allocations',
            module: "budget.and.schedule"
          },
          permissions: ['batch.allocation.manage', 'batch.allocation.list']
        }
      },
      {
        path: 'trainings/questions',
        loadChildren: () => import('../budget-and-schedule/question/list/question-list.module').then(x => x.QuestionListModule),
        data: {
          name: 'question_list',
          breadcrumb: {
            icon: 'safety',
            title: 'questions',
            module: "budget.and.schedule"
          },
          permissions: ['question.manage', 'question.list']
        }
      },
      {
        path: 'trainings/my-exam',
        loadChildren: () => import('../budget-and-schedule/batch-schedule/exam/my-exam/my-exam-list.module').then(x => x.MyExamListModule),
        data: {
          name: 'my_exam_list',
          breadcrumb: {
            icon: 'safety',
            title: 'my.exams'
          },
          permissions: ['myexam.manage']
        }
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
