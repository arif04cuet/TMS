import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { BatchScheduleListComponent } from './batch-schedule-list.component';
import { BatchScheduleListRoutingModule } from './batch-schedule-list-routing.module';
import { BatchScheduleHttpService } from 'src/services/http/budget-and-schedule/batch-schedule-http.service';

@NgModule({
  declarations: [
    BatchScheduleListComponent
  ],
  imports: [
    CommonModule,
    BatchScheduleListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule
  ],
  exports: [BatchScheduleListComponent],
  providers: [
    BatchScheduleHttpService
  ]
})
export class BatchScheduleListModule { }