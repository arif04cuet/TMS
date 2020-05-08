import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccessoryCheckoutListRoutingModule } from './accessory-checkout-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AccessoryHttpService } from 'src/services/http/asset/accessory-http.service';
import { AccessoryCheckoutListComponent } from './accessory-checkout-list.component';


@NgModule({
  declarations: [
    AccessoryCheckoutListComponent
  ],
  imports: [
    CommonModule,
    AccessoryCheckoutListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [AccessoryCheckoutListComponent],
  providers: [
    AccessoryHttpService
  ]
})
export class AccessoryCheckoutListModule { }
