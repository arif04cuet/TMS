import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NgZorroAntdModule, NzFormModule, NzRadioModule, NzInputModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';
import { ExamAnswerRoutingModule } from './exam-answer-routing.module';
import { ExamAnswerComponent } from './exam-answer.component';

@NgModule({
  declarations: [
    ExamAnswerComponent
  ],
  imports: [
    CommonModule,
    ExamAnswerRoutingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    NzRadioModule,
    NzInputModule
  ],
  exports: [ExamAnswerComponent],
  providers: [
    ExamHttpService
  ]
})
export class ExamAnswerModule { }
