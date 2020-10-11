import { NgModule } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { getLang } from 'src/services/utilities.service';


@NgModule({
  declarations: [],
  imports: [
    TranslateModule
  ],
  exports: [
    TranslateModule
  ]
})
export class SharedModule {
  constructor(private translate: TranslateService) {
    translate.use(getLang());
  }
}