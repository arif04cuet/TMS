import { NgModule } from '@angular/core';
import { CourseComponent } from './course.component';
import { NzGridModule, NzCardModule } from 'ng-zorro-antd';
import { CommonModule } from '@angular/common';
import { TrainingCourseHttpService } from 'src/services/training-course-http-service';




@NgModule({
  declarations: [
    CourseComponent
  ],
  exports: [CourseComponent],
  imports: [
    CommonModule,
    NzGridModule,
    NzCardModule
  ],
  providers: [
    TrainingCourseHttpService
  ]
})
export class CourseModule { }
