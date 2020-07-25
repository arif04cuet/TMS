import { NgModule } from '@angular/core';
import { TrainingCourseApplyComponent } from './training-course-apply.component';
import { NzFormModule, NzInputModule, NzButtonModule, NzTagModule } from 'ng-zorro-antd';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { TrainingCourseHttpService } from 'src/services/training-course-http-service';
import { SelectControlModule } from 'src/shared/select-control/select-control.module';

@NgModule({
  declarations: [
    TrainingCourseApplyComponent
  ],
  exports: [TrainingCourseApplyComponent],
  imports: [
    CommonModule,
    NzButtonModule,
    ScrollingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NzInputModule,
    NzTagModule,
    SelectControlModule
  ],
  providers: [
    TrainingCourseHttpService
  ]
})
export class TrainingCourseApplyModule { }
