import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccessoryAddComponent } from './accessory-add.component';
import { AccessoryAddRoutingModule } from './accessory-add-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';

@NgModule({
  declarations: [
    AccessoryAddComponent
  ],
  imports: [
    AccessoryAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [AccessoryAddComponent],
  providers: [
    CommonValidator
  ]
})
export class AccessoryAddModule { }
