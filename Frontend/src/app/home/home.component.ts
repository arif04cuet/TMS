import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent{

  home=false;

  constructor(private router: Router) {
    router.events.subscribe(x => {
       if(x instanceof NavigationEnd) {
         this.home = window.location.href.split("#").pop() == '/';
         console.log(this.home);
       }
    });
  }

}
