import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ComponentDetailsModule } from './details/component-details.module';
import { ComponentCheckoutListModule } from './list/component-checkout-list.module';
import { ComponentCheckoutHistoryModule } from './history/component-checkout-history.module';
import { ComponentViewComponent } from './component-view.component';
import { ComponentViewRoutingModule } from './component-view-routing.module';


@NgModule({
  declarations: [
    ComponentViewComponent
  ],
  imports: [
    ComponentViewRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    ComponentDetailsModule,
    ComponentCheckoutListModule,
    ComponentCheckoutHistoryModule
  ],
  exports: [ComponentViewComponent]
})
export class ComponentViewModule { }
