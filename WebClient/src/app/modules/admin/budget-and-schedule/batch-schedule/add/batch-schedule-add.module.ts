import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { BatchScheduleAddComponent } from './batch-schedule-add.component';
import { CourseScheduleHttpService } from 'src/services/http/budget-and-schedule/course-schedule-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { BatchScheduleAddRoutingModule } from './batch-schedule-add-routing.module'
import { ParticipantsModule } from '../participants/participants.module';
import { BatchScheduleRoutineAddModule } from '../routine/batch-schedule-routine-add.module';

@NgModule({
  declarations: [
    BatchScheduleAddComponent
  ],
  imports: [
    BatchScheduleAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    ParticipantsModule,
    BatchScheduleRoutineAddModule
  ],
  exports: [BatchScheduleAddComponent],
  providers: [
    CourseScheduleHttpService,
    BatchScheduleHttpService,
    UserHttpService,
    CommonValidator
  ]
})
export class BatchScheduleAddModule { }
