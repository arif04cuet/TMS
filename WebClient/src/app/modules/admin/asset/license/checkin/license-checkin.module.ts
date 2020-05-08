import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LicenseCheckinRoutingModule } from './license-checkin-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { LicenseCheckinComponent } from './license-checkin.component';
import { ViewModule } from 'src/app/shared/view.component';

@NgModule({
  declarations: [
    LicenseCheckinComponent
  ],
  imports: [
    LicenseCheckinRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    ViewModule
  ],
  exports: [LicenseCheckinComponent]
})
export class LicenseCheckinModule { }
