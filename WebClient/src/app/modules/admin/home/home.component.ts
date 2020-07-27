import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { AuthService } from 'src/services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { PermissionHttpService } from 'src/services/http/user/permission-http.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends BaseComponent {

  nav = [];
  userInfo;

  constructor(
    private authService: AuthService,
    private activatedRoute: ActivatedRoute,
    private permissionHttpService: PermissionHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this.snapshot(this.activatedRoute.snapshot);
    this.on('breadcrumbs', (data: any[]) => {
      this.breadcrumbs = data;
    })
    this.userInfo = this.authService.getLoggedInUserInfo();
    this.nav = [
      {
        level: 1,
        title: 'dashboard',
        route: '/admin',
        icon: 'dashboard',
      },
      {
        level: 1,
        title: 'my.exam',
        route: '/admin/trainings/my-exam',
        icon: 'dashboard',
      },

      {
        level: 1,
        title: 'cms',
        icon: 'user',
        nav: [
          {
            level: 2,
            title: 'cms.category',
            route: '/admin/cms/categories',
            icon: 'user'
          },
          {
            level: 2,
            title: 'cms.content',
            route: '/admin/cms/contents',
            icon: 'user'
          },
          {
            level: 2,
            title: 'cms.banner',
            route: '/admin/cms/banners',
            icon: 'user'
          }
        ]
      },
      {
        level: 1,
        title: 'user',
        icon: 'team',
        nav: [
          {
            level: 2,
            title: 'users',
            route: '/admin/users',
            icon: 'user'
          },
          {
            level: 2,
            title: 'roles',
            route: '/admin/roles',
            icon: 'safety'
          },
          {
            level: 2,
            title: 'offices',
            route: '/admin/offices',
            icon: 'safety'
          },
          {
            level: 2,
            title: 'designations',
            route: '/admin/designations',
            icon: 'safety'
          },
          {
            level: 2,
            title: 'departments',
            route: '/admin/departments',
            icon: 'safety'
          }
        ]
      },
      {
        level: 1,
        title: 'library',
        icon: 'team',
        nav: [
          {
            level: 2,
            title: 'libraries',
            route: '/admin/libraries',
            icon: 'user'
          },
          {
            level: 2,
            title: 'members',
            route: '/admin/library/members',
            icon: 'user'
          },
          {
            level: 2,
            title: 'member.requests',
            route: '/admin/library/members/requests',
            icon: 'user'
          },
          {
            level: 2,
            title: 'cards',
            route: '/admin/library/cards',
            icon: 'user'
          },
          {
            level: 2,
            title: 'book.catalog',
            route: '/admin/library/books',
            icon: 'user'
          },
          {
            level: 2,
            title: 'books',
            route: '/admin/library/books/items',
            icon: 'user'
          },
          {
            level: 2,
            title: 'book.issue',
            route: '/admin/library/books/items/issues',
            icon: 'user'
          },
          {
            level: 2,
            title: 'racks',
            route: '/admin/library/racks',
            icon: 'user'
          },
          {
            level: 2,
            title: 'authors',
            route: '/admin/library/authors',
            icon: 'user'
          },
          {
            level: 2,
            title: 'publishers',
            route: '/admin/library/publishers',
            icon: 'user'
          },
          {
            level: 2,
            title: 'book.categories',
            route: '/admin/library/categories',
            icon: 'user'
          },
          {
            level: 2,
            title: 'reports',
            icon: 'user',
            nav: [
              {
                level: 3,
                title: 'issue',
                icon: 'user',
                route: '/admin/library/issues',
              },
              {
                level: 3,
                title: 'fine',
                icon: 'user',
                route: '/admin/library/fines',
              }
            ]
          }
        ]
      },
      {
        level: 1,
        title: 'asset',
        icon: 'team',
        nav: [
          {
            level: 2,
            title: 'assets',
            icon: 'user',
            nav: [
              {
                level: 3,
                title: 'list',
                route: '/admin/asset',
                icon: 'user'
              },
              {
                level: 3,
                title: 'maintenances',
                route: '/admin/asset/maintenances',
                icon: 'user'
              },
              {
                level: 3,
                title: 'audit',
                route: '/admin/asset/audit/add',
                icon: 'user'
              },
              {
                level: 3,
                title: 'bulk.checkout',
                route: '/admin/asset/checkout/bulk',
                icon: 'user'
              },
            ]
          },
          {
            level: 2,
            title: 'license',
            route: '/admin/asset/licenses',
            icon: 'user'
          },
          // {
          //   level: 2,
          //   title: 'accessory',
          //   route: '/admin/asset/accessories',
          //   icon: 'user'
          // },
          {
            level: 2,
            title: 'consumable',
            route: '/admin/asset/consumables',
            icon: 'user'
          },
          // {
          //   level: 2,
          //   title: 'component',
          //   route: '/admin/asset/components',
          //   icon: 'user'
          // },
          {
            level: 2,
            title: 'settings',
            icon: 'setting',
            nav: [
              {
                level: 3,
                title: 'asset.models',
                route: '/admin/asset/models',
                icon: 'user'
              },
              {
                level: 3,
                title: 'consumable.item.code',
                route: '/admin/asset/itemcodes/consumable',
                icon: 'user'
              },
              // {
              //   level: 3,
              //   title: 'license.item.code',
              //   route: '/admin/asset/itemcodes/license',
              //   icon: 'user'
              // },
              {
                level: 3,
                title: 'supplier',
                route: '/admin/asset/suppliers',
                icon: 'user'
              },
              {
                level: 3,
                title: 'depreciation',
                route: '/admin/asset/depreciations',
                icon: 'user'
              },
              {
                level: 3,
                title: 'manufacturer',
                route: '/admin/asset/manufacturers',
                icon: 'user'
              },
              {
                level: 3,
                title: 'status',
                route: '/admin/asset/statuses',
                icon: 'user'
              },
              {
                level: 3,
                title: 'category',
                route: '/admin/asset/categories',
                icon: 'user'
              }
            ]
          },
          {
            level: 2,
            title: 'reports',
            icon: 'setting',
            nav: [
              {
                level: 3,
                title: 'activity.log',
                route: '/admin/asset/reports/activity-log',
                icon: 'user'
              },
              {
                level: 3,
                title: 'audit.log',
                route: '/admin/asset/reports/audit-log',
                icon: 'user'
              },
              {
                level: 3,
                title: 'depreciation.report',
                route: '/admin/asset/reports/depreciation',
                icon: 'user'
              },
              {
                level: 3,
                title: 'license.report',
                route: '/admin/asset/reports/license',
                icon: 'user'
              },
              {
                level: 3,
                title: 'maintenance.report',
                route: '/admin/asset/reports/maintenance',
                icon: 'user'
              },
              {
                level: 3,
                title: 'asset.report',
                route: '/admin/asset/reports/asset',
                icon: 'user'
              },
            ]
          }
        ]
      },
      {
        level: 1,
        title: 'hostel',
        icon: 'team',
        nav: [
          {
            level: 2,
            title: 'allocations',
            icon: 'team',
            route: '/admin/hostels/allocations',
          },
          {
            level: 2,
            title: 'hostels',
            icon: 'team',
            route: '/admin/hostels',
          },
          {
            level: 2,
            title: 'buildings',
            icon: 'team',
            route: '/admin/hostels/buildings',
          },
          {
            level: 2,
            title: 'rooms',
            icon: 'team',
            route: '/admin/hostels/rooms',
          },
          {
            level: 2,
            title: 'beds',
            icon: 'team',
            route: '/admin/hostels/beds',
          },
          {
            level: 2,
            title: 'room.types',
            icon: 'team',
            route: '/admin/hostels/rooms/types',
          },
          {
            level: 2,
            title: 'facilities',
            icon: 'team',
            route: '/admin/hostels/facilities',
          }
        ]
      },
      {
        level: 1,
        title: 'course',
        icon: 'team',
        nav: [
          {
            level: 2,
            title: 'courses',
            icon: 'team',
            route: '/admin/courses'
          },
          {
            level: 2,
            title: 'modules',
            icon: 'team',
            route: '/admin/courses/modules'
          },
          {
            level: 2,
            title: 'topics',
            icon: 'team',
            route: '/admin/courses/topics'
          },
          {
            level: 2,
            title: 'categories',
            icon: 'team',
            route: '/admin/courses/categories'
          },
          {
            level: 2,
            title: 'course.methods',
            icon: 'team',
            route: '/admin/courses/methods'
          },
          {
            level: 2,
            title: 'evaluation.methods',
            icon: 'team',
            route: '/admin/courses/evaluation-methods'
          },
          {
            level: 2,
            title: 'grades',
            icon: 'team',
            route: '/admin/courses/grades'
          },
          {
            level: 2,
            title: 'expertise',
            icon: 'team',
            route: '/admin/courses/expertise'
          },
          {
            level: 2,
            title: 'resource.persons',
            icon: 'team',
            route: '/admin/courses/resource-persons'
          },
        ]
      },
      {
        level: 1,
        title: 'budget.and.schedule',
        icon: 'team',
        nav: [
          {
            level: 2,
            title: 'course.schedules',
            icon: 'team',
            route: '/admin/trainings/course-schedules'
          },
          {
            level: 2,
            title: 'batch.schedules',
            icon: 'team',
            route: '/admin/trainings/batch-schedules'
          },
          {
            level: 2,
            title: 'batch.allocation',
            icon: 'team',
            route: '/admin/trainings/batch-schedules/allocations'
          },
          {
            level: 2,
            title: 'questions',
            icon: 'team',
            route: '/admin/trainings/questions'
          },
          {
            level: 2,
            title: 'honorarium.heads',
            icon: 'team',
            route: '/admin/trainings/honorarium-heads'
          }
        ]
      }
    ]

    //this.checkPermissions();
  }

  logout() {
    this.authService.logout();
    this.goTo('/');
  }

  profile() {
    this.goTo('/admin/profile')
  }

  onMenuItemClick(n) {
    if (n.route) {
      this.goTo(n.route);
    }
  }

  navigate(b) {
    if (!b.last) {
      this.goTo(b.route);
    }
  }

  checkPermissions() {
    const body = {
      userId: this.authService.getLoggedInUserId(),
      permissions: ['user.create', 'user.update']
    }
    this.subscribe(this.permissionHttpService.check(body),
      (res: any) => {
        this.log('permissions', res);
      },
      err => {

      }
    );
  }

}
