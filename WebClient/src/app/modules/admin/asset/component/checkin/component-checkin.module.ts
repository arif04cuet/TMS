import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ComponentCheckinRoutingModule } from './component-checkin-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ViewModule } from 'src/app/shared/view.component';
import { ComponentCheckinComponent } from './component-checkin.component';

@NgModule({
  declarations: [
    ComponentCheckinComponent
  ],
  imports: [
    ComponentCheckinRoutingModule,
    CommonModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    ViewModule
  ],
  exports: [ComponentCheckinComponent]
})
export class ComponentCheckinModule { }
