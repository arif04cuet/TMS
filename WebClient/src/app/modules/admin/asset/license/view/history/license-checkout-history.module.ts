import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { LicenseHttpService } from 'src/services/http/asset/license-http.service';
import { LicenseCheckoutHistoryComponent } from './license-checkout-history.component';
import { LicenseCheckoutHistoryRoutingModule } from './license-checkout-history-routing.module';


@NgModule({
  declarations: [
    LicenseCheckoutHistoryComponent
  ],
  imports: [
    CommonModule,
    LicenseCheckoutHistoryRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [LicenseCheckoutHistoryComponent],
  providers: [
    LicenseHttpService
  ]
})
export class LicenseCheckoutHistoryModule { }
