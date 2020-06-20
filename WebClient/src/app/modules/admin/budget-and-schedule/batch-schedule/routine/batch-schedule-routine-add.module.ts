import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { CourseScheduleHttpService } from 'src/services/http/budget-and-schedule/course-schedule-http.service';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { ParticipantsModule } from '../participants/participants.module';
import { BatchScheduleRoutineAddComponent } from './batch-schedule-routine-add.component';
import { BatchScheduleRoutineAddRoutingModule } from './batch-schedule-routine-add-routing.module';
import { ModuleHttpService } from 'src/services/http/course/module-http.service';
import { ResourcePersonHttpService } from 'src/services/http/course/resource-person-http.service';
import { BatchScheduleRoutineHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-routine.http.service';

@NgModule({
  declarations: [
    BatchScheduleRoutineAddComponent
  ],
  imports: [
    BatchScheduleRoutineAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    ParticipantsModule
  ],
  exports: [BatchScheduleRoutineAddComponent],
  providers: [
    CourseScheduleHttpService,
    BatchScheduleHttpService,
    CommonValidator,
    ModuleHttpService,
    ResourcePersonHttpService,
    BatchScheduleRoutineHttpService
  ]
})
export class BatchScheduleRoutineAddModule { }
