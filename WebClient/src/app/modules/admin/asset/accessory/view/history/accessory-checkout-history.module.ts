import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { AccessoryHttpService } from 'src/services/http/asset/accessory-http.service';
import { AccessoryCheckoutHistoryComponent } from './accessory-checkout-history.component';
import { AccessoryCheckoutHistoryRoutingModule } from './accessory-checkout-history-routing.module';


@NgModule({
  declarations: [
    AccessoryCheckoutHistoryComponent
  ],
  imports: [
    CommonModule,
    AccessoryCheckoutHistoryRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AccessoryCheckoutHistoryComponent],
  providers: [
    AccessoryHttpService
  ]
})
export class AccessoryCheckoutHistoryModule { }
