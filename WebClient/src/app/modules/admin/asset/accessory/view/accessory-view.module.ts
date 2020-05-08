import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccessoryViewComponent } from './accessory-view.component';
import { AccessoryViewRoutingModule } from './accessory-view-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AccessoryDetailsModule } from './details/accessory-details.module';
import { AccessoryCheckoutListModule } from './list/accessory-checkout-list.module';
import { AccessoryCheckoutHistoryModule } from './history/accessory-checkout-history.module';


@NgModule({
  declarations: [
    AccessoryViewComponent
  ],
  imports: [
    AccessoryViewRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    AccessoryDetailsModule,
    AccessoryCheckoutListModule,
    AccessoryCheckoutHistoryModule
  ],
  exports: [AccessoryViewComponent]
})
export class AccessoryViewModule { }
