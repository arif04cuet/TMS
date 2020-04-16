import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { AuthService } from 'src/services/auth.service';
import { ActivatedRoute } from '@angular/router';

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
    private activatedRoute: ActivatedRoute
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
            title: 'vendors',
            route: '/admin/asset/vendors',
            icon: 'user'
          }
        ]
      }
    ]
  }

  logout() {
    this.authService.logout();
    this.goTo('/');
  }

  profile() {
    this.goTo('/admin/profile')
  }

  onMenuItemClick(n) {
    this.log('on menu item click', n);
    if (n.route) {
      this.goTo(n.route);
    }
  }

  navigate(b) {
    if (!b.last) {
      this.goTo(b.route);
    }
  }

}
