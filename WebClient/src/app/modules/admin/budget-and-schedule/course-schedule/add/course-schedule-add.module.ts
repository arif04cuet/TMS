import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CommonValidator } from 'src/validators/common.validator';
import { CourseScheduleAddComponent } from './course-schedule-add.component';
import { CourseScheduleHttpService } from 'src/services/http/budget-and-schedule/course-schedule-http.service';
import { CourseScheduleAddRoutingModule } from './course-schedule-add-routing.module';
import { SelectControlModule } from 'src/app/shared/select-control/select-control.module';
import { DesignationHttpService } from 'src/services/http/user/designation-http.service';
import { CourseHttpService } from 'src/services/http/course/course-http.service';
import { UserHttpService } from 'src/services/http/user/user-http.service';
import { SelectModule } from 'src/app/shared/select/select.module';

@NgModule({
  declarations: [
    CourseScheduleAddComponent
  ],
  imports: [
    CourseScheduleAddRoutingModule,
    CommonModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    SelectControlModule,
    SelectModule
  ],
  exports: [CourseScheduleAddComponent],
  providers: [
    CourseScheduleHttpService,
    DesignationHttpService,
    CourseHttpService,
    UserHttpService,
    CommonValidator
  ]
})
export class CourseScheduleAddModule { }
