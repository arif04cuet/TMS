import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConsumableCheckoutRoutingModule } from './consumable-checkout-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ConsumableCheckoutComponent } from './consumable-checkout.component';
import { ViewModule } from 'src/app/shared/view.component';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';

@NgModule({
  declarations: [
    ConsumableCheckoutComponent
  ],
  imports: [
    ConsumableCheckoutRoutingModule,
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
  exports: [ConsumableCheckoutComponent],
  providers: [
    CommonValidator,
    ConsumableHttpService,
    UserHttpService
  ]
})
export class ConsumableCheckoutModule { }
