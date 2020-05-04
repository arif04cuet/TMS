import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LicenseDetailsComponent } from './license-details.component';
import { LicenseDetailsRoutingModule } from './license-details-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';


@NgModule({
  declarations: [
    LicenseDetailsComponent
  ],
  imports: [
    LicenseDetailsRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [LicenseDetailsComponent],
  providers: [
    CommonValidator,
    LicenseHttpService,
    UserHttpService
  ]
})
export class LicenseDetailsModule { }
