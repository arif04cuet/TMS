import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ConsumableCheckoutHistoryRoutingModule } from './consumable-checkout-history-routing.module';
import { ConsumableCheckoutHistoryComponent } from './consumable-checkout-history.component';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';


@NgModule({
  declarations: [
    ConsumableCheckoutHistoryComponent
  ],
  imports: [
    CommonModule,
    ConsumableCheckoutHistoryRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ConsumableCheckoutHistoryComponent],
  providers: [
    ConsumableHttpService
  ]
})
export class ConsumableCheckoutHistoryModule { }
