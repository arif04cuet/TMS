import { NgModule } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';


@NgModule({
  imports: [
    TranslateModule
  ],
  exports: [
    TranslateModule
  ]
})
export class SharedModule {
  constructor(private translate: TranslateService) {
    const lang = localStorage.getItem('lang') || 'en';
    translate.use(lang);
  }
}