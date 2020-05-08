import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConsumableCheckinRoutingModule } from './consumable-checkin-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ConsumableCheckinComponent } from './consumable-checkin.component';
import { ViewModule } from 'src/app/shared/view.component';

@NgModule({
  declarations: [
    ConsumableCheckinComponent
  ],
  imports: [
    ConsumableCheckinRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    ViewModule
  ],
  exports: [ConsumableCheckinComponent]
})
export class ConsumableCheckinModule { }
