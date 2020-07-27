import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';
import { MyExamStartComponent } from './my-exam-start.component';
import { MyExamStartRoutingModule } from './my-exam-start-routing.module';

@NgModule({
  declarations: [
    MyExamStartComponent
  ],
  imports: [
    CommonModule,
    MyExamStartRoutingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [MyExamStartComponent],
  providers: [
    ExamHttpService
  ]
})
export class MyExamStartModule { }
