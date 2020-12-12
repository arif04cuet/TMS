import { NgModule } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { BoxLoaderModule } from './box-loader.component';
import { getLang } from 'src/services/utilities.service';
import { MomentPipeModule } from 'src/pipes/moment.pipe';
import { CheckPermissionDirective } from 'src/directives/permission.directive';
import { EnToBnDirective } from 'src/directives/en-to-bn.directive';
import { BanglaPipe } from 'src/pipes/bangla.pipe';
import { BanglaDatePipe } from 'src/pipes/bangla-date.pipe';



@NgModule({
  declarations: [
    CheckPermissionDirective,
    EnToBnDirective,
    BanglaPipe,
    BanglaDatePipe
  ],
  imports: [
    TranslateModule,
    BoxLoaderModule,
    MomentPipeModule
  ],
  exports: [
    TranslateModule,
    BoxLoaderModule,
    MomentPipeModule,
    CheckPermissionDirective,
    EnToBnDirective,
    BanglaPipe,
    BanglaDatePipe
  ]
})
export class SharedModule {
  constructor(private translate: TranslateService) {
    translate.use(getLang());
  }
}