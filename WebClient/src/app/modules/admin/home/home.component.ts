import { Component } from '@angular/core';
import { BaseComponent } from 'src/app/shared/base.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends BaseComponent {

  nav = [];

  constructor() {
    super();
  }

  ngOnInit(): void {
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
            title: 'Permissions',
            route: '/admin/permissions',
            icon: 'safety'
          },
          {
            level: 2,
            title: 'Designations',
            route: '/admin/designations',
            icon: 'safety'
          }
        ]
      }
    ]
  }

  onMenuItemClick(n) {
    this.log('on menu item click', n);
    if (n.route) {
      this.goTo(n.route);
    }
  }

}
