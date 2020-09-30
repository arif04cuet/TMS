import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CourseScheduleListComponent } from './course-schedule-list.component';
import { CourseScheduleListRoutingModule } from './course-schedule-list-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { CourseScheduleHttpService } from 'src/services/http/budget-and-schedule/course-schedule-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    CourseScheduleListComponent
  ],
  imports: [
    CommonModule,
    CourseScheduleListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [CourseScheduleListComponent],
  providers: [
    CourseScheduleHttpService
  ]
})
export class CourseScheduleListModule { }