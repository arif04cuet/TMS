import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { BatchScheduleAllocationHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-allocation-http.service';
import { BatchScheduleAllocationListComponent } from './batch-schedule-allocation-list.component';
import { BatchScheduleAllocationListRoutingModule } from './batch-schedule-allocation-list-routing.module';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';
import { CourseHttpService } from 'src/services/http/course/course-http.service';
import { SelectModule } from 'src/app/shared/select/select.module';

@NgModule({
  declarations: [
    BatchScheduleAllocationListComponent
  ],
  imports: [
    CommonModule,
    BatchScheduleAllocationListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectModule
  ],
  exports: [BatchScheduleAllocationListComponent],
  providers: [
    BatchScheduleAllocationHttpService,
    BatchScheduleHttpService,
    CourseHttpService
  ]
})
export class BatchScheduleAllocationListModule { }