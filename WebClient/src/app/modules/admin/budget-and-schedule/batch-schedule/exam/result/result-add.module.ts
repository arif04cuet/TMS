import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';
import { ResultAddComponent } from './result-add.component';
import { ResultAddRoutingModule } from './result-add-routing.module';

@NgModule({
  declarations: [
    ResultAddComponent
  ],
  imports: [
    ResultAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [ResultAddComponent],
  providers: [
    ExamHttpService,
    CommonValidator
  ]
})
export class ResultAddModule { }
