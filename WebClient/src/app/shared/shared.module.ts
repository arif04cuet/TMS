import { NgModule } from '@angular/core';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { BoxLoaderModule } from './box-loader.component';
import { getLang } from 'src/services/utilities.service';
import { MomentPipeModule } from 'src/pipes/moment.pipe';
import { CheckPermissionDirective } from 'src/directives/permission.directive';
import { EnToBnDirective } from 'src/directives/en-to-bn.directive';


@NgModule({
  declarations: [
    CheckPermissionDirective,
    EnToBnDirective
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
    EnToBnDirective
  ]
})
export class SharedModule {
  constructor(private translate: TranslateService) {
    translate.use(getLang());
  }
}