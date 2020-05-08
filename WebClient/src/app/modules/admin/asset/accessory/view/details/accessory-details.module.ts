import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccessoryDetailsComponent } from './accessory-details.component';
import { AccessoryDetailsRoutingModule } from './accessory-details-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AccessoryHttpService } from 'src/services/http/asset/accessory-http.service';


@NgModule({
  declarations: [
    AccessoryDetailsComponent
  ],
  imports: [
    AccessoryDetailsRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [AccessoryDetailsComponent],
  providers: [
    AccessoryHttpService
  ]
})
export class AccessoryDetailsModule { }
