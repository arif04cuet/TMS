import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { TotalMarkComponent } from './total-mark.component';
import { TotalMarkRoutingModule } from './total-mark-routing.module';
import { TotalMarksHttpService } from 'src/services/http/budget-and-schedule/total-marks-http.service';

@NgModule({
  declarations: [
    TotalMarkComponent
  ],
  imports: [
    TotalMarkRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [TotalMarkComponent],
  providers: [
    TotalMarksHttpService,
    CommonValidator
  ]
})
export class TotalMarkModule { }
