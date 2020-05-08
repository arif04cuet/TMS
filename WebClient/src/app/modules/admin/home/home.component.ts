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
        title: 'user.management',
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
        title: 'library.management',
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
            title: 'categories',
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
        title: 'asset.management',
        icon: 'team',
        nav: [
          {
            level: 2,
            title: 'license',
            route: '/admin/asset/licenses',
            icon: 'user'
          },
          {
            level: 2,
            title: 'accessory',
            route: '/admin/asset/accessories',
            icon: 'user'
          },
          {
            level: 2,
            title: 'consumable',
            route: '/admin/asset/consumables',
            icon: 'user'
          },
          {
            level: 2,
            title: 'component',
            route: '/admin/asset/components',
            icon: 'user'
          },
          {
            level: 2,
            title: 'settings',
            icon: 'setting',
            nav: [
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
