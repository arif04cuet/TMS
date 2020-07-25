import { NgModule } from '@angular/core';
import { TrainingCourseViewComponent } from './training-course-view.component';
import { NzFormModule, NzInputModule, NzButtonModule, NzTagModule } from 'ng-zorro-antd';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { TrainingCourseHttpService } from 'src/services/training-course-http-service';

@NgModule({
  declarations: [
    TrainingCourseViewComponent
  ],
  exports: [TrainingCourseViewComponent],
  imports: [
    CommonModule,
    NzButtonModule,
    ScrollingModule,
    FormsModule,
    NzFormModule,
    ReactiveFormsModule,
    NzInputModule,
    NzTagModule
  ],
  providers: [
    TrainingCourseHttpService
  ]
})
export class TrainingCourseViewModule { }
