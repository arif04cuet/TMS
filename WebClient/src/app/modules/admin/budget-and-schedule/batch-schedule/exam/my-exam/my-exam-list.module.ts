import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';
import { MyExamListComponent } from './my-exam-list.component';
import { MyExamListRoutingModule } from './my-exam-list-routing.module';

@NgModule({
  declarations: [
    MyExamListComponent
  ],
  imports: [
    CommonModule,
    MyExamListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [MyExamListComponent],
  providers: [
    ExamHttpService
  ]
})
export class MyExamListModule { }