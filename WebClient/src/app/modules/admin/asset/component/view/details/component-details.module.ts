import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ConsumableHttpService } from 'src/services/http/asset/consumable-http.service';
import { ComponentDetailsComponent } from './component-details.component';
import { ComponentDetailsRoutingModule } from './component-details-routing.module';


@NgModule({
  declarations: [
    ComponentDetailsComponent
  ],
  imports: [
    ComponentDetailsRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [ComponentDetailsComponent],
  providers: [
    ConsumableHttpService
  ]
})
export class ComponentDetailsModule { }
