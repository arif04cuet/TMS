import { NgModule } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { getLang } from 'src/services/utilities.service';
import { BanglaPipe } from 'src/pipes/bangla.pipe';


@NgModule({
  declarations: [
    BanglaPipe
  ],
  imports: [
    TranslateModule
  ],
  exports: [
    TranslateModule,
    BanglaPipe
  ]
})
export class SharedModule {
  constructor(private translate: TranslateService) {
    translate.use(getLang());
  }
}