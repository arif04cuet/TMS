import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ComponentHttpService } from 'src/services/http/asset/component-http.service';
import { ComponentCheckoutListComponent } from './component-checkout-list.component';
import { ComponentCheckoutListRoutingModule } from './component-checkout-list-routing.module';


@NgModule({
  declarations: [
    ComponentCheckoutListComponent
  ],
  imports: [
    CommonModule,
    ComponentCheckoutListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ComponentCheckoutListComponent],
  providers: [
    ComponentHttpService
  ]
})
export class ComponentCheckoutListModule { }
