import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConsumableCheckoutListRoutingModule } from './consumable-checkout-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ConsumableCheckoutListComponent } from './consumable-checkout-list.component';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';


@NgModule({
  declarations: [
    ConsumableCheckoutListComponent
  ],
  imports: [
    CommonModule,
    ConsumableCheckoutListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ConsumableCheckoutListComponent],
  providers: [
    ConsumableHttpService
  ]
})
export class ConsumableCheckoutListModule { }
