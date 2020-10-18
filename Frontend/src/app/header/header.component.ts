import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {

  constructor(private router: Router) {

  }

  navigate(route: string) {
    this.router.navigateByUrl(route)
  }

  goToUrl(url: string): void {
    window.location.href = url;
  }

}
