import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends BaseComponent {

  nav = [];
  userInfo;

  constructor(
    private authService: AuthService
  ) {
    super();
  }

  ngOnInit(): void {
    this.userInfo = this.authService.getLoggedInUserInfo();
    this.nav = [
      {
        level: 1,
        title: 'Dashboard',
        route: '/admin',
        icon: 'dashboard',
      },
      {
        level: 1,
        title: 'User Management',
        icon: 'team',
        nav: [
          {
            level: 2,
            title: 'Users',
            route: '/admin/users',
            icon: 'user'
          },
          {
            level: 2,
            title: 'Roles',
            route: '/admin/roles',
            icon: 'safety'
          },
          {
            level: 2,
            title: 'Designations',
            route: '/admin/designations',
            icon: 'safety'
          }
        ]
      },
      {
        level: 1,
        title: 'Asset Management',
        icon: 'team',
        nav: [
          {
            level: 2,
            title: 'Vendors',
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

}
