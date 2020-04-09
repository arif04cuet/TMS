import { Component, Injector } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  
  constructor(private injector: Injector) {
    AppInjector = injector
  }

}

export let AppInjector: Injector;
