import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ViewModule } from 'src/app/shared/view.component';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';
import { ComponentCheckoutComponent } from './component-checkout.component';
import { ComponentCheckoutRoutingModule } from './component-checkout-routing.module';
import { AssetBaseHttpService } from 'src/services/http/asset/asset-http-service';

@NgModule({
  declarations: [
    ComponentCheckoutComponent
  ],
  imports: [
    ComponentCheckoutRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    ViewModule
  ],
  exports: [ComponentCheckoutComponent],
  providers: [
    CommonValidator,
    ConsumableHttpService,
    AssetBaseHttpService
  ]
})
export class ComponentCheckoutModule { }
