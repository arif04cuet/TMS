import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [

      {
        path: 'cms/banners',
        loadChildren: () => import('../cms/banner/list/banner-list.module').then(x => x.BannerListModule),
        data: {
          name: 'cms_banners',
          breadcrumb: {
            icon: 'team',
            title: 'cms.banner'
          }
        }
      },

      {
        path: 'cms/contents',
        loadChildren: () => import('../cms/content/list/content-list.module').then(x => x.CmsContentListModule),
        data: {
          name: 'cms_contents',
          breadcrumb: {
            icon: 'team',
            title: 'cms.content'
          }
        }
      },


      {
        path: 'cms/categories',
        loadChildren: () => import('../cms/category/list/category-list.module').then(x => x.CmsCategoryListModule),
        data: {
          name: 'cms_categories',
          breadcrumb: {
            icon: 'team',
            title: 'cms.category'
          }
        }
      },


      {
        path: 'users',
        loadChildren: () => import('../user/user/list/user-list.module').then(x => x.UserListModule),
        data: {
          name: 'user_list',
          breadcrumb: {
            icon: 'team',
            title: 'users'
          }
        }
      },
      {
        path: 'roles',
        loadChildren: () => import('../user/role/list/role-list.module').then(x => x.RoleListModule),
        data: {
          name: 'role_list',
          breadcrumb: {
            icon: 'safety',
            title: 'roles'
          }
        }
      },
      {
        path: 'offices',
        loadChildren: () => import('../user/office/list/office-list.module').then(x => x.OfficeListModule),
        data: {
          name: 'office_list',
          breadcrumb: {
            icon: 'safety',
            title: 'offices'
          }
        }
      },
      {
        path: 'designations',
        loadChildren: () => import('../user/designation/list/designation-list.module').then(x => x.DesignationListModule),
        data: {
          name: 'designation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'designations'
          }
        }
      },
      {
        path: 'departments',
        loadChildren: () => import('../user/department/list/department-list.module').then(x => x.DepartmentListModule),
        data: {
          name: 'department_list',
          breadcrumb: {
            icon: 'safety',
            title: 'departments'
          }
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
          }
        }
      },
      {
        path: 'libraries',
        loadChildren: () => import('../library/library/list/library-list.module').then(x => x.LibraryListModule),
        data: {
          name: 'library_list',
          breadcrumb: {
            icon: 'safety',
            title: 'libraries'
          }
        }
      },
      {
        path: 'library/members',
        loadChildren: () => import('../library/member/list/member-list.module').then(x => x.MemberListModule),
        data: {
          name: 'library_member_list',
          breadcrumb: {
            icon: 'safety',
            title: 'members'
          }
        }
      },
      {
        path: 'library/members/requests',
        loadChildren: () => import('../library/member/request-list/request-list.module').then(x => x.MemberRequestListModule),
        data: {
          name: 'library_members_requests_list',
          breadcrumb: {
            icon: 'safety',
            title: 'members'
          }
        }
      },
      {
        path: 'library/cards',
        loadChildren: () => import('../library/card/list/card-list.module').then(x => x.CardListModule),
        data: {
          name: 'library_card_list',
          breadcrumb: {
            icon: 'safety',
            title: 'cards'
          }
        }
      },
      {
        path: 'library/books',
        loadChildren: () => import('../library/book/list/book-list.module').then(x => x.BookListModule),
        data: {
          name: 'book_list',
          breadcrumb: {
            icon: 'safety',
            title: 'books'
          }
        }
      },
      {
        path: 'library/books/items',
        loadChildren: () => import('../library/book-item/list/book-item-list.module').then(x => x.BookItemListModule),
        data: {
          name: 'book_item_list',
          breadcrumb: {
            icon: 'safety',
            title: 'books'
          },
          permissions: ['user.manage']
        }
      },
      {
        path: 'library/racks',
        loadChildren: () => import('../library/rack/list/rack-list.module').then(x => x.RackListModule),
        data: {
          name: 'rack_list',
          breadcrumb: {
            icon: 'safety',
            title: 'racks'
          }
        }
      },
      {
        path: 'library/authors',
        loadChildren: () => import('../library/author/list/author-list.module').then(x => x.AuthorListModule),
        data: {
          name: 'author_list',
          breadcrumb: {
            icon: 'safety',
            title: 'authors'
          }
        }
      },
      {
        path: 'library/publishers',
        loadChildren: () => import('../library/publisher/list/publisher-list.module').then(x => x.PublisherListModule),
        data: {
          name: 'publisher_list',
          breadcrumb: {
            icon: 'safety',
            title: 'publishers'
          }
        }
      },
      {
        path: 'library/categories',
        loadChildren: () => import('../library/subject/list/subject-list.module').then(x => x.SubjectListModule),
        data: {
          name: 'category_list',
          breadcrumb: {
            icon: 'safety',
            title: 'categories'
          }
        }
      },
      {
        path: 'library/issues',
        loadChildren: () => import('../library/issue/list/issue-list.module').then(x => x.IssueListModule),
        data: {
          name: 'issue_list',
          breadcrumb: {
            icon: 'safety',
            title: 'issues'
          }
        }
      },
      {
        path: 'library/fines',
        loadChildren: () => import('../library/fine/list/fine-list.module').then(x => x.FineListModule),
        data: {
          name: 'fine_list',
          breadcrumb: {
            icon: 'safety',
            title: 'fines'
          }
        }
      },
      {
        path: 'asset',
        loadChildren: () => import('../asset/asset/list/asset-list.module').then(x => x.AssetListModule),
        data: {
          name: 'asset_list',
          breadcrumb: {
            icon: 'safety',
            title: 'assets'
          }
        }
      },
      {
        path: 'asset/maintenances',
        loadChildren: () => import('../asset/asset/view/maintenance/list/asset-maintenance-list.module').then(x => x.AssetMaintenanceListModule),
        data: {
          name: 'maintenance_list',
          breadcrumb: {
            icon: 'plus',
            title: 'Add'
          }
        }
      },
      {
        path: 'asset/models',
        loadChildren: () => import('../asset/asset-model/list/asset-model-list.module').then(x => x.AssetModelListModule),
        data: {
          name: 'asset_model_list',
          breadcrumb: {
            icon: 'safety',
            title: 'asset.models'
          }
        }
      },
      {
        path: 'asset/audit',
        loadChildren: () => import('../asset/asset/audit/add/asset-audit-add.module').then(x => x.AssetAuditAddModule),
        data: {
          name: 'asset_audit_add',
          breadcrumb: {
            icon: 'safety',
            title: 'audit'
          }
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
            title: 'asset.itemcode'
          }
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
            title: 'consumable'
          }
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
            title: 'supplier'
          }
        }
      },
      {
        path: 'asset/depreciations',
        loadChildren: () => import('../asset/depreciation/list/depreciation-list.module').then(x => x.DepreciationListModule),
        data: {
          name: 'depreciation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'Depreciation'
          }
        }
      },

      {
        path: 'asset/manufacturers',
        loadChildren: () => import('../asset/manufacturer/list/manufacturer-list.module').then(x => x.ManufacturerListModule),
        data: {
          name: 'manufacturer_list',
          breadcrumb: {
            icon: 'safety',
            title: 'manufacturer'
          }
        }
      },
      {
        path: 'asset/statuses',
        loadChildren: () => import('../asset/status/list/status-list.module').then(x => x.StatusListModule),
        data: {
          name: 'status_list',
          breadcrumb: {
            icon: 'safety',
            title: 'status'
          }
        }
      },
      {
        path: 'asset/categories',
        loadChildren: () => import('../asset/category/list/category-list.module').then(x => x.CategoryListModule),
        data: {
          name: 'category_list',
          breadcrumb: {
            icon: 'safety',
            title: 'category'
          }
        }
      },
      {
        path: 'asset/licenses',
        loadChildren: () => import('../asset/license/list/license-list.module').then(x => x.LicenseListModule),
        data: {
          name: 'license_list',
          breadcrumb: {
            icon: 'safety',
            title: 'license'
          }
        }
      },
      {
        path: 'asset/reports/activity-log',
        loadChildren: () => import('../asset/reports/activity-log/asset-activity-log.module').then(x => x.AssetActivityLogModule),
        data: {
          name: 'asset_activity_log',
          breadcrumb: {
            icon: 'safety',
            title: 'activity.log'
          }
        }
      },
      {
        path: 'asset/reports/audit-log',
        loadChildren: () => import('../asset/reports/audit-log/asset-audit-log.module').then(x => x.AssetAuditLogModule),
        data: {
          name: 'asset_audit_log',
          breadcrumb: {
            icon: 'safety',
            title: 'audit.log'
          }
        }
      },
      {
        path: 'asset/reports/depreciation',
        loadChildren: () => import('../asset/reports/depreciation/depreciation-report.module').then(x => x.DepreciationReportModule),
        data: {
          name: 'asset_depreciation_report',
          breadcrumb: {
            icon: 'safety',
            title: 'depreciation.report'
          }
        }
      },
      {
        path: 'asset/reports/license',
        loadChildren: () => import('../asset/reports/license/license-report.module').then(x => x.LicenseReportModule),
        data: {
          name: 'asset_license_report',
          breadcrumb: {
            icon: 'safety',
            title: 'license.report'
          }
        }
      },
      {
        path: 'asset/reports/maintenance',
        loadChildren: () => import('../asset/reports/maintenance/maintenance-report.module').then(x => x.MaintenanceReportModule),
        data: {
          name: 'asset_maintenance_report',
          breadcrumb: {
            icon: 'safety',
            title: 'maintenance.report'
          }
        }
      },
      {
        path: 'asset/reports/asset',
        loadChildren: () => import('../asset/reports/asset/asset-report.module').then(x => x.AssetReportModule),
        data: {
          name: 'asset_asset_report',
          breadcrumb: {
            icon: 'safety',
            title: 'asset.report'
          }
        }
      },
      {
        path: 'hostels/allocations',
        loadChildren: () => import('../hostel/allocation/list/allocation-list.module').then(x => x.AllocationListModule),
        data: {
          name: 'allocation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'allocations'
          }
        }
      },
      {
        path: 'hostels',
        loadChildren: () => import('../hostel/hostel/list/hostel-list.module').then(x => x.HostelListModule),
        data: {
          name: 'hostel_list',
          breadcrumb: {
            icon: 'safety',
            title: 'hostels'
          }
        }
      },
      {
        path: 'hostels/buildings',
        loadChildren: () => import('../hostel/building/list/building-list.module').then(x => x.BuildingListModule),
        data: {
          name: 'building_list',
          breadcrumb: {
            icon: 'safety',
            title: 'buildings'
          }
        }
      },
      {
        path: 'hostels/facilities',
        loadChildren: () => import('../hostel/facilities/list/facilities-list.module').then(x => x.FacilitiesListModule),
        data: {
          name: 'facilities_list',
          breadcrumb: {
            icon: 'safety',
            title: 'facilities'
          }
        }
      },
      {
        path: 'hostels/rooms',
        loadChildren: () => import('../hostel/room/list/room-list.module').then(x => x.RoomListModule),
        data: {
          name: 'room_list',
          breadcrumb: {
            icon: 'safety',
            title: 'rooms'
          }
        }
      },
      {
        path: 'hostels/beds',
        loadChildren: () => import('../hostel/bed/list/bed-list.module').then(x => x.BedListModule),
        data: {
          name: 'bed_list',
          breadcrumb: {
            icon: 'safety',
            title: 'beds'
          }
        }
      },
      {
        path: 'courses/grades',
        loadChildren: () => import('../course/grade/list/grade-list.module').then(x => x.GradeListModule),
        data: {
          name: 'grade_list',
          breadcrumb: {
            icon: 'safety',
            title: 'grades'
          }
        }
      },
      {
        path: 'courses/evaluation-methods',
        loadChildren: () => import('../course/evaluation-method/list/evaluation-method-list.module').then(x => x.EvaluationMethodListModule),
        data: {
          name: 'evaluation_method_list',
          breadcrumb: {
            icon: 'safety',
            title: 'evaluation.methods'
          }
        }
      },
      {
        path: 'courses/methods',
        loadChildren: () => import('../course/method/list/method-list.module').then(x => x.MethodListModule),
        data: {
          name: 'course_method_list',
          breadcrumb: {
            icon: 'safety',
            title: 'course.methods'
          }
        }
      },
      {
        path: 'courses/categories',
        loadChildren: () => import('../course/category/list/category-list.module').then(x => x.CategoryListModule),
        data: {
          name: 'course_category_list',
          breadcrumb: {
            icon: 'safety',
            title: 'course.categories'
          }
        }
      },
      {
        path: 'courses/topics',
        loadChildren: () => import('../course/topic/list/topic-list.module').then(x => x.TopicListModule),
        data: {
          name: 'course_topic_list',
          breadcrumb: {
            icon: 'safety',
            title: 'topics'
          }
        }
      },
      {
        path: 'courses/modules',
        loadChildren: () => import('../course/module/list/module-list.module').then(x => x.ModuleListModule),
        data: {
          name: 'course_module_list',
          breadcrumb: {
            icon: 'safety',
            title: 'modules'
          }
        }
      },
      {
        path: 'courses',
        loadChildren: () => import('../course/course/list/course-list.module').then(x => x.CourseListModule),
        data: {
          name: 'course_list',
          breadcrumb: {
            icon: 'safety',
            title: 'courses'
          }
        }
      },
      {
        path: 'courses/resource-persons',
        loadChildren: () => import('../course/resource-person/list/resource-person-list.module').then(x => x.ResourcePersonListModule),
        data: {
          name: 'resource_persons_list',
          breadcrumb: {
            icon: 'safety',
            title: 'resource.persons'
          }
        }
      },
      {
        path: 'courses/expertise',
        loadChildren: () => import('../course/expertise/list/expertise-list.module').then(x => x.ExpertiseListModule),
        data: {
          name: 'expertise_list',
          breadcrumb: {
            icon: 'safety',
            title: 'expertise'
          }
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
            title: 'honorarium.heads'
          }
        }
      },
      {
        path: 'trainings/course-schedules',
        loadChildren: () => import('../budget-and-schedule/course-schedule/list/course-schedule-list.module').then(x => x.CourseScheduleListModule),
        data: {
          name: 'course_schedule_list',
          breadcrumb: {
            icon: 'safety',
            title: 'course.schedules'
          }
        }
      },
      {
        path: 'trainings/batch-schedules',
        loadChildren: () => import('../budget-and-schedule/batch-schedule/list/batch-schedule-list.module').then(x => x.BatchScheduleListModule),
        data: {
          name: 'batch_schedule_list',
          breadcrumb: {
            icon: 'safety',
            title: 'batch.schedules'
          }
        }
      },
      {
        path: 'trainings/batch-schedules/allocations',
        loadChildren: () => import('../budget-and-schedule/batch-schedule/allocation/list/batch-schedule-allocation-list.module').then(x => x.BatchScheduleAllocationListModule),
        data: {
          name: 'batch_schedule_allocation_list',
          breadcrumb: {
            icon: 'safety',
            title: 'allocations'
          }
        }
      },
      {
        path: 'trainings/questions',
        loadChildren: () => import('../budget-and-schedule/question/list/question-list.module').then(x => x.QuestionListModule),
        data: {
          name: 'question_list',
          breadcrumb: {
            icon: 'safety',
            title: 'questions'
          }
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
          }
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
