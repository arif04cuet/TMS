import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls:['./homepage.component.css']
})
export class HomePageComponent {

  constructor(private router: Router) {

  }

  navigate(route: string) {
    this.router.navigateByUrl(route)
  }

}
