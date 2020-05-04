import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { LicenseSeatsComponent } from './license-seats.component';
import { LicenseSeatsRoutingModule } from './license-seats-routing.module';


@NgModule({
  declarations: [
    LicenseSeatsComponent
  ],
  imports: [
    LicenseSeatsRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [LicenseSeatsComponent],
  providers: [
    CommonValidator,
    LicenseHttpService,
    UserHttpService
  ]
})
export class LicenseSeatsModule { }
