import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConsumableViewComponent } from './consumable-view.component';
import { ConsumableViewRoutingModule } from './consumable-view-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ConsumableDetailsModule } from './details/consumable-details.module';
import { ConsumableCheckoutListModule } from './list/consumable-checkout-list.module';
import { ConsumableCheckoutHistoryModule } from './history/consumable-checkout-history.module';


@NgModule({
  declarations: [
    ConsumableViewComponent
  ],
  imports: [
    ConsumableViewRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    ConsumableDetailsModule,
    ConsumableCheckoutListModule,
    ConsumableCheckoutHistoryModule
  ],
  exports: [ConsumableViewComponent]
})
export class ConsumableViewModule { }
