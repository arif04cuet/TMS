import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { AuthService } from 'src/services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { PermissionHttpService } from 'src/services/http/user/permission-http.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends BaseComponent {

  nav = [];
  userInfo;
  permissionLoaded = false;

  constructor(
    private authService: AuthService,
    private activatedRoute: ActivatedRoute,
    private permissionService: PermissionHttpService
  ) {
    super();
  }

  ngOnInit(): void {
    this.snapshot(this.activatedRoute.snapshot);
    this.on('breadcrumbs', (data: any[]) => {
      this.breadcrumbs = data;
    })
    this.userInfo = this.authService.getLoggedInUserInfo();

    const nav = [
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
        fn: () => true,
      },
      {
        level: 1,
        title: 'cms',
        icon: 'user',
        fn: () => {
          return this.permissionService.isRouteGranted(['content.category', 'content', 'content.banner', 'content.faq']);
        },
        nav: [
          {
            level: 2,
            title: 'cms.category',
            route: '/admin/cms/categories',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('content.category');
            },
          },
          {
            level: 2,
            title: 'cms.content',
            route: '/admin/cms/contents',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('content');
            },
          },
          {
            level: 2,
            title: 'cms.banner',
            route: '/admin/cms/banners',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('content.banner');
            },
          },
          {
            level: 2,
            title: 'cms.faq',
            route: '/admin/cms/faq',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('content.faq');
            },
          }
        ]
      },
      {
        level: 1,
        title: 'user.management',
        icon: 'team',
        fn: () => {
          return this.permissionService.isRouteGranted(['user', 'role', 'designation', 'department']);
        },
        nav: [
          {
            level: 2,
            title: 'users',
            route: '/admin/users',
            fn: () => {
              return this.permissionService.isRouteGranted('user');
            },
          },
          {
            level: 2,
            title: 'roles',
            route: '/admin/roles',
            icon: 'safety',
            fn: () => {
              return this.permissionService.isRouteGranted('role');
            },
          },
          {
            level: 2,
            title: 'offices',
            route: '/admin/offices',
            icon: 'safety',
            fn: () => {
              return this.permissionService.isRouteGranted('office');
            }
          },
          {
            level: 2,
            title: 'designations',
            route: '/admin/designations',
            icon: 'safety',
            fn: () => {
              return this.permissionService.isRouteGranted('designation');
            },
          },
          {
            level: 2,
            title: 'departments',
            route: '/admin/departments',
            icon: 'safety',
            fn: () => {
              return this.permissionService.isRouteGranted('department');
            },
          }
        ]
      },
      {
        level: 1,
        title: 'library.management',
        icon: 'team',
        fn: () => {
          return this.permissionService.isRouteGranted(['library', 'library.member', 'library.member.request', 'card', 'book.catalog', 'book', 'book.issue', 'rack', 'author', 'publisher', 'book.category', '#library.report.issue', '#library.report.fine']);
        },
        nav: [
          {
            level: 2,
            title: 'libraries',
            route: '/admin/libraries',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('library');
            }
          },
          {
            level: 2,
            title: 'members',
            route: '/admin/library/members',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('library.member');
            }
          },
          {
            level: 2,
            title: 'member.requests',
            route: '/admin/library/members/requests',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('library.member.request');
            }
          },
          {
            level: 2,
            title: 'cards',
            route: '/admin/library/cards',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('card');
            }
          },
          {
            level: 2,
            title: 'book.catalog',
            route: '/admin/library/books',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('book.catalog');
            }
          },
          {
            level: 2,
            title: 'books',
            route: '/admin/library/books/items',
            icon: 'user',
            fn: () => {
              console.log('dddddd granted');
              return this.permissionService.isRouteGranted('book');
            }
          },
          {
            level: 2,
            title: 'book.issue',
            route: '/admin/library/books/items/issues',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('book.issue');
            }
          },
          {
            level: 2,
            title: 'racks',
            route: '/admin/library/racks',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('rack');
            }
          },
          {
            level: 2,
            title: 'authors',
            route: '/admin/library/authors',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('author');
            }
          },
          {
            level: 2,
            title: 'publishers',
            route: '/admin/library/publishers',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('publisher');
            }
          },
          {
            level: 2,
            title: 'book.categories',
            route: '/admin/library/categories',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('book.category');
            }
          },
          {
            level: 2,
            title: 'reports',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted(['#library.report.issue', '#library.report.fine']);
            },
            nav: [
              {
                level: 3,
                title: 'issue',
                icon: 'user',
                route: '/admin/library/issues',
                fn: () => {
                  return this.permissionService.isRouteGranted('#library.report.issue');
                },
              },
              {
                level: 3,
                title: 'fine',
                icon: 'user',
                route: '/admin/library/fines',
                fn: () => {
                  return this.permissionService.isRouteGranted('#library.report.fine');
                },
              }
            ]
          }
        ]
      },
      {
        level: 1,
        title: 'asset.management',
        icon: 'team',
        fn: () => {
          return this.permissionService.isRouteGranted(['asset', 'maintenance', '#asset.audit.create', '#asset.bulk.checkout', 'license', 'consumable', 'asset.model', 'item.code', 'supplier', 'depreciation', 'manufacturer', 'asset.status', 'asset.category', '#report.activity.log', '#report.audit.log', '#report.depreciation', '#report.license', '#report.maintenance', '#report.asset']);
        },
        nav: [
          {
            level: 2,
            title: 'assets',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted(['asset', 'maintenance', '#asset.audit.create', '#asset.bulk.checkout']);
            },
            nav: [
              {
                level: 3,
                title: 'list',
                route: '/admin/asset',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('asset');
                },
              },
              {
                level: 3,
                title: 'maintenances',
                route: '/admin/asset/maintenances',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('maintenance');
                },
              },
              {
                level: 3,
                title: 'audit',
                route: '/admin/asset/audit/add',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('#asset.audit.create');
                },
              },
              {
                level: 3,
                title: 'bulk.checkout',
                route: '/admin/asset/checkout/bulk',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('#asset.bulk.checkout');
                },
              },
            ]
          },
          {
            level: 2,
            title: 'license',
            route: '/admin/asset/licenses',
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('license');
            },
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
            icon: 'user',
            fn: () => {
              return this.permissionService.isRouteGranted('consumable');
            },
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
            fn: () => {
              return this.permissionService.isRouteGranted(['asset.model', 'item.code', 'supplier', 'depreciation', 'manufacturer', 'asset.status', 'asset.category']);
            },
            nav: [
              {
                level: 3,
                title: 'asset.models',
                route: '/admin/asset/models',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('asset.model');
                },
              },
              {
                level: 3,
                title: 'consumable.item.code',
                route: '/admin/asset/itemcodes/consumable',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('item.code');
                },
              },
              {
                level: 3,
                title: 'supplier',
                route: '/admin/asset/suppliers',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('supplier');
                },
              },
              {
                level: 3,
                title: 'depreciation',
                route: '/admin/asset/depreciations',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('depreciation');
                },
              },
              {
                level: 3,
                title: 'manufacturer',
                route: '/admin/asset/manufacturers',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('manufacturer');
                },
              },
              {
                level: 3,
                title: 'status',
                route: '/admin/asset/statuses',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('asset.status');
                },
              },
              {
                level: 3,
                title: 'category',
                route: '/admin/asset/categories',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('asset.category');
                },
              }
            ]
          },
          {
            level: 2,
            title: 'reports',
            icon: 'setting',
            fn: () => {
              return this.permissionService.isRouteGranted(['#report.activity.log', '#report.audit.log', '#report.depreciation', '#report.license', '#report.maintenance', '#report.asset']);
            }, 
            nav: [
              {
                level: 3,
                title: 'activity.log',
                route: '/admin/asset/reports/activity-log',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('#report.activity.log');
                },
              },
              {
                level: 3,
                title: 'audit.log',
                route: '/admin/asset/reports/audit-log',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('#report.audit.log');
                },
              },
              {
                level: 3,
                title: 'depreciation.report',
                route: '/admin/asset/reports/depreciation',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('#report.depreciation');
                },
              },
              {
                level: 3,
                title: 'license.report',
                route: '/admin/asset/reports/license',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('#report.license');
                },
              },
              {
                level: 3,
                title: 'maintenance.report',
                route: '/admin/asset/reports/maintenance',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('#report.maintenance');
                },
              },
              {
                level: 3,
                title: 'asset.report',
                route: '/admin/asset/reports/asset',
                icon: 'user',
                fn: () => {
                  return this.permissionService.isRouteGranted('report.asset');
                },
              },
            ]
          }
        ]
      },
      {
        level: 1,
        title: 'hostel.management',
        icon: 'team',
        fn: () => {
          return this.permissionService.isRouteGranted(['allocation', 'hostel', 'building', 'room', 'bed', 'room.type', 'room.facilities']);
        },
        nav: [
          {
            level: 2,
            title: 'allocations',
            icon: 'team',
            route: '/admin/hostels/allocations',
            fn: () => {
              return this.permissionService.isRouteGranted('allocation');
            },
          },
          {
            level: 2,
            title: 'hostels',
            icon: 'team',
            route: '/admin/hostels',
            fn: () => {
              return this.permissionService.isRouteGranted('hostel');
            },
          },
          {
            level: 2,
            title: 'buildings',
            icon: 'team',
            route: '/admin/hostels/buildings',
            fn: () => {
              return this.permissionService.isRouteGranted('building');
            },
          },
          {
            level: 2,
            title: 'rooms',
            icon: 'team',
            route: '/admin/hostels/rooms',
            fn: () => {
              return this.permissionService.isRouteGranted('room');
            },
          },
          {
            level: 2,
            title: 'beds',
            icon: 'team',
            route: '/admin/hostels/beds',
            fn: () => {
              return this.permissionService.isRouteGranted('bed');
            },
          },
          {
            level: 2,
            title: 'room.types',
            icon: 'team',
            route: '/admin/hostels/rooms/types',
            fn: () => {
              return this.permissionService.isRouteGranted('room.type');
            },
          },
          {
            level: 2,
            title: 'facilities',
            icon: 'team',
            route: '/admin/hostels/facilities',
            fn: () => {
              return this.permissionService.isRouteGranted('room.facilities');
            },
          }
        ]
      },
      {
        level: 1,
        title: 'course.management',
        icon: 'team',
        fn: () => {
          return this.permissionService.isRouteGranted(['course', 'module', 'topic', 'course.category', 'method', 'evaluation.method', 'grade', 'expertise', 'resource.person']);
        },
        nav: [
          {
            level: 2,
            title: 'courses',
            icon: 'team',
            route: '/admin/courses',
            fn: () => {
              return this.permissionService.isRouteGranted('course');
            },
          },
          {
            level: 2,
            title: 'modules',
            icon: 'team',
            route: '/admin/courses/modules',
            fn: () => {
              return this.permissionService.isRouteGranted('module');
            },
          },
          {
            level: 2,
            title: 'topics',
            icon: 'team',
            route: '/admin/courses/topics',
            fn: () => {
              return this.permissionService.isRouteGranted('topic');
            },
          },
          {
            level: 2,
            title: 'categories',
            icon: 'team',
            route: '/admin/courses/categories',
            fn: () => {
              return this.permissionService.isRouteGranted('course.category');
            },
          },
          {
            level: 2,
            title: 'course.methods',
            icon: 'team',
            route: '/admin/courses/methods',
            fn: () => {
              return this.permissionService.isRouteGranted('method');
            },
          },
          {
            level: 2,
            title: 'evaluation.methods',
            icon: 'team',
            route: '/admin/courses/evaluation-methods',
            fn: () => {
              return this.permissionService.isRouteGranted('evaluation.method');
            },
          },
          {
            level: 2,
            title: 'grades',
            icon: 'team',
            route: '/admin/courses/grades',
            fn: () => {
              return this.permissionService.isRouteGranted('grade');
            },
          },
          {
            level: 2,
            title: 'expertise',
            icon: 'team',
            route: '/admin/courses/expertise',
            fn: () => {
              return this.permissionService.isRouteGranted('expertise');
            },
          },
          {
            level: 2,
            title: 'resource.persons',
            icon: 'team',
            route: '/admin/courses/resource-persons',
            fn: () => {
              return this.permissionService.isRouteGranted('resource.person');
            }
          },
        ]
      },
      {
        level: 1,
        title: 'budget.and.schedule',
        icon: 'team',
        fn: () => {
          return this.permissionService.isRouteGranted(['schedule', 'batch', 'batch.allocation', 'question', 'honorarium.head']);
        },
        nav: [
          {
            level: 2,
            title: 'course.schedules',
            icon: 'team',
            route: '/admin/trainings/course-schedules',
            fn: () => {
              return this.permissionService.isRouteGranted('schedule');
            },
          },
          {
            level: 2,
            title: 'batch.schedules',
            icon: 'team',
            route: '/admin/trainings/batch-schedules',
            fn: () => {
              return this.permissionService.isRouteGranted('batch');
            },
          },
          {
            level: 2,
            title: 'batch.allocation',
            icon: 'team',
            route: '/admin/trainings/batch-schedules/allocations',
            fn: () => {
              return this.permissionService.isRouteGranted('batch.allocation');
            },
          },
          {
            level: 2,
            title: 'questions',
            icon: 'team',
            route: '/admin/trainings/questions',
            fn: () => {
              return this.permissionService.isRouteGranted('question');
            },
          },
          {
            level: 2,
            title: 'honorarium.heads',
            icon: 'team',
            route: '/admin/trainings/honorarium-heads',
            fn: () => {
              return this.permissionService.isRouteGranted('honorarium.head');
            },
          }
        ]
      }
    ]

    this.checkPermissions();
    this.checkNavGrant(nav);
    this.nav = nav;
    this.permissionLoaded = true;
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
    this.subscribe(this.permissionService.check(body),
      (res: any) => {
        this.log('permissions', res);
      },
      err => {

      }
    );
  }

  checkNavGrant(nav: any[]) {
    nav.forEach(n => {
      if (n.fn) {
        n.granted = n.fn(this.permissionService.getPermissions());
      }
      else {
        n.granted = false;
      }
      if (n.nav) {
        this.checkNavGrant(n.nav)
      }
    });
  }

}
