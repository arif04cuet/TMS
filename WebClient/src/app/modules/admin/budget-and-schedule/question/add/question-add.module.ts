import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { CourseScheduleHttpService } from 'src/services/http/budget-and-schedule/course-schedule-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { QuestionAddRoutingModule } from './question-add-routing.module'
import { QuestionHttpService } from 'src/services/http/budget-and-schedule/question-http.service';
import { QuestionAddComponent } from './question-add.component';

@NgModule({
  declarations: [
    QuestionAddComponent
  ],
  imports: [
    QuestionAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [QuestionAddComponent],
  providers: [
    CourseScheduleHttpService,
    QuestionHttpService,
    UserHttpService,
    CommonValidator
  ]
})
export class QuestionAddModule { }
