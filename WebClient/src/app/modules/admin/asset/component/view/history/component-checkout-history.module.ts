import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';
import { ComponentCheckoutHistoryComponent } from './component-checkout-history.component';
import { ComponentCheckoutHistoryRoutingModule } from './component-checkout-history-routing.module';


@NgModule({
  declarations: [
    ComponentCheckoutHistoryComponent
  ],
  imports: [
    CommonModule,
    ComponentCheckoutHistoryRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ComponentCheckoutHistoryComponent],
  providers: [
    ComponentHttpService
  ]
})
export class ComponentCheckoutHistoryModule { }
