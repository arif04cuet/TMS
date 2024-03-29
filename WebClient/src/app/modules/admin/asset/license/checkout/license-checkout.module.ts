import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LicenseCheckoutComponent } from './license-checkout.component';
import { LicenseCheckoutRoutingModule } from './license-checkout-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ViewModule } from 'src/app/shared/view.component';

@NgModule({
  declarations: [
    LicenseCheckoutComponent
  ],
  imports: [
    LicenseCheckoutRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    ViewModule
  ],
  exports: [LicenseCheckoutComponent],
  providers: [
    CommonValidator
  ]
})
export class LicenseCheckoutModule { }
