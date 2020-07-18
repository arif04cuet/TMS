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
import { ExamHomeModule } from '../exam/home/exam-home.module';
import { SessionProgressModule } from '../session-progress/session-progress.module';
import { HonorariumModule } from '../honorarium/honorarium.module';
import { CertificatesModule } from '../certificates/certificates.module';
import { TotalMarkModule } from '../total-mark/total-mark.module';
import { BatchScheduleGalleryModule } from '../gallery/batch-schedule-gallery.module';

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
    BatchScheduleRoutineAddModule,
    ExamHomeModule,
    SessionProgressModule,
    HonorariumModule,
    CertificatesModule,
    TotalMarkModule,
    BatchScheduleGalleryModule
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
