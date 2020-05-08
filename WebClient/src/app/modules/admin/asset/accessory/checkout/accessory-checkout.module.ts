import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccessoryCheckoutRoutingModule } from './accessory-checkout-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AccessoryCheckoutComponent } from './accessory-checkout.component';
import { ViewModule } from 'src/app/shared/view.component';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { AccessoryHttpService } from 'src/services/http/asset/accessory-http.service';

@NgModule({
  declarations: [
    AccessoryCheckoutComponent
  ],
  imports: [
    AccessoryCheckoutRoutingModule,
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
  exports: [AccessoryCheckoutComponent],
  providers: [
    CommonValidator,
    AccessoryHttpService,
    UserHttpService
  ]
})
export class AccessoryCheckoutModule { }
