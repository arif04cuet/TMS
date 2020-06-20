import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HonorariumHeadAddComponent } from './honorarium-head-add.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { HonorariumHeadAddRoutingModule } from './honorarium-head-add-routing.module';
import { HonorariumHeadHttpService } from 'src/services/http/budget-and-schedule/honorarium-head-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';

@NgModule({
  declarations: [
    HonorariumHeadAddComponent
  ],
  imports: [
    HonorariumHeadAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [HonorariumHeadAddComponent],
  providers: [
    HonorariumHeadHttpService,
    DesignationHttpService,
    CommonValidator
  ]
})
export class HonorariumHeadAddModule { }
