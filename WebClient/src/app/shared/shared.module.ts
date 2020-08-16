import { NgModule } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { BoxLoaderModule } from './box-loader.component';
import { getLang } from 'src/services/utilities.service';
import { MomentPipeModule } from 'src/pipes/moment.pipe';
import { CheckPermissionDirective } from 'src/directives/permission.directive';


@NgModule({
  declarations: [
    CheckPermissionDirective
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
    CheckPermissionDirective
  ]
})
export class SharedModule {
  constructor(private translate: TranslateService) {
    translate.use(getLang());
  }
}