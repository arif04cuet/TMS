import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccessoryCheckinRoutingModule } from './accessory-checkin-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { AccessoryCheckinComponent } from './accessory-checkin.component';
import { ViewModule } from 'src/app/shared/view.component';

@NgModule({
  declarations: [
    AccessoryCheckinComponent
  ],
  imports: [
    AccessoryCheckinRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    ViewModule
  ],
  exports: [AccessoryCheckinComponent]
})
export class AccessoryCheckinModule { }
