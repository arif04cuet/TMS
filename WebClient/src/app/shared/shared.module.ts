import { NgModule } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { BoxLoaderModule } from './box-loader.component';
import { getLang } from 'src/services/utilities.service';


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
    translate.use(getLang());
  }
}