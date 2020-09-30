import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { NzTableModule, NgZorroAntdModule, NzFormModule } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { CourseListComponent } from './course-list.component';
import { CourseListRoutingModule } from './course-list-routing.module';
import { CourseHttpService } from 'src/services/http/course/course-http.service';
import { TableActionsModule } from 'src/app/shared/table-actions.component';

@NgModule({
  declarations: [
    CourseListComponent
  ],
  imports: [
    CommonModule,
    CourseListRoutingModule,
    NzTableModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    SharedModule,
    TableActionsModule
  ],
  exports: [CourseListComponent],
  providers: [
    CourseHttpService
  ]
})
export class CourseListModule { }
