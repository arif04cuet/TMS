import { Component, Injector } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  constructor(private injector: Injector) {
    AppInjector = injector
  }

  ngOnInit() {
    if (environment.production) {
      localStorage.setItem('otms_lang', 'en');
    }
  }

}

export let AppInjector: Injector;
