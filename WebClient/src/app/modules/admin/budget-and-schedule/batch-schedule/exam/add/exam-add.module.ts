import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule, NzModalService } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { ExamAddComponent } from './exam-add.component';
import { ExamAddRoutingModule } from './exam-add-routing.module';
import { ExamHttpService } from 'src/services/http/budget-and-schedule/exam-http.service';
import { QuestionModalModule } from '../question-modal/question-modal.module';
import { MomentPipeModule, MomentPipe } from 'src/pipes/moment.pipe';

@NgModule({
  declarations: [
    ExamAddComponent
  ],
  imports: [
    ExamAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    QuestionModalModule,
    MomentPipeModule
  ],
  exports: [ExamAddComponent],
  providers: [
    ExamHttpService,
    CommonValidator,
    NzModalService,
    MomentPipe
  ]
})
export class ExamAddModule { }
