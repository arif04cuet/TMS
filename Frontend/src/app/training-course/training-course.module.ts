import { NgModule } from '@angular/core';
import { TrainingCourseComponent } from './training-course.component';
import { NzFormModule, NzInputModule, NzSelectModule, NzButtonModule, NzTagModule } from 'ng-zorro-antd';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { SelectModule } from 'src/shared/select/select.module';
import { TrainingCourseHttpService } from 'src/services/training-course-http-service';

@NgModule({
  declarations: [
    TrainingCourseComponent
  ],
  exports: [TrainingCourseComponent],
  imports: [
    CommonModule,
    NzButtonModule,
    ScrollingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NzInputModule,
    NzSelectModule,
    SelectModule,
    NzTagModule
  ],
  providers: [
    TrainingCourseHttpService
  ]
})
export class TrainingCourseModule { }
