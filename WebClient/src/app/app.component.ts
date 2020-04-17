import { Component, Injector } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  constructor(private injector: Injector) {
    AppInjector = injector
  }

  ngOnInit() {
    const key = 'otms_lang';
    const lang = localStorage.getItem(key);
    if (!lang) {
      localStorage.setItem(key, 'en');
    }
  }

}

export let AppInjector: Injector;
