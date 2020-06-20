import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { BatchScheduleAllocationAddRoutingModule } from './batch-schedule-allocation-add-routing.module'
import { BatchScheduleAllocationAddComponent } from './batch-schedule-allocation-add.component';
import { BatchScheduleAllocationHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-allocation-http.service';
import { CourseHttpService } from 'src/services/http/course/course-http.service';

@NgModule({
  declarations: [
    BatchScheduleAllocationAddComponent
  ],
  imports: [
    BatchScheduleAllocationAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule
  ],
  exports: [BatchScheduleAllocationAddComponent],
  providers: [
    BatchScheduleAllocationHttpService,
    BatchScheduleHttpService,
    CourseHttpService,
    UserHttpService,
    CommonValidator
  ]
})
export class BatchScheduleAllocationAddModule { }
