import { Component, Injector } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  constructor(private injector: Injector, private router: Router,
    private activatedRoute: ActivatedRoute,
    private titleService: Title) {
    AppInjector = injector
  }

  ngOnInit() {
    if (environment.production) {
      localStorage.setItem('otms_lang', 'en');
    }

    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd),
    ).subscribe(() => {
      const rt = this.getChild(this.activatedRoute);
      rt.data.subscribe(data => {
        this.titleService.setTitle(data.title)
      });
    });


  }

  getChild(activatedRoute: ActivatedRoute) {
    if (activatedRoute.firstChild) {
      return this.getChild(activatedRoute.firstChild);
    } else {
      return activatedRoute;
    }

  }


}

export let AppInjector: Injector;
