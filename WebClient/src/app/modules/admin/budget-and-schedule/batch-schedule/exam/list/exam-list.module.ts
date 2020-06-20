import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExamListComponent } from './exam-list.component';
import { ExamListRoutingModule } from './exam-list-routing.module';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';

@NgModule({
  declarations: [
    ExamListComponent
  ],
  imports: [
    CommonModule,
    ExamListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [ExamListComponent],
  providers: [
    ExamHttpService
  ]
})
export class ExamListModule { }