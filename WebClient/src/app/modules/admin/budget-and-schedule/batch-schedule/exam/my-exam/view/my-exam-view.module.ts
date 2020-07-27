import { NgModule } from '@angular/core';

import { CommonModule, DatePipe } from '@angular/common';
import { NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { MyExamViewComponent } from './my-exam-view.component';
import { MyExamViewRoutingModule } from './my-exam-view-routing.module';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';

@NgModule({
  declarations: [
    MyExamViewComponent
  ],
  imports: [
    CommonModule,
    MyExamViewRoutingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [MyExamViewComponent],
  providers: [
    ExamHttpService
  ]
})
export class MyExamViewModule { }
