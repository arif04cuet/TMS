import { NgModule } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { BoxLoaderModule } from './box-loader.component';


@NgModule({
  imports: [
    TranslateModule,
    BoxLoaderModule
  ],
  exports: [
    TranslateModule,
    BoxLoaderModule
  ]
})
export class SharedModule {
  constructor(private translate: TranslateService) {
    const lang = localStorage.getItem('otms_lang') || 'en';
    translate.use(lang);
  }
}