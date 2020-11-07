import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/services/auth.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {

  loggedIn = false;

  constructor(private router: Router, private authService: AuthService) {

    this.loggedIn = this.authService.isAuthenticated() ? true : false;

  }

  navigate(route: string) {
    this.router.navigateByUrl(route)
  }

  goToUrl(url: string): void {
    window.location.href = url;
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/');
  }

}
