import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CourseScheduleAddComponent } from './course-schedule-add.component';

const routes: Routes = [
  { path: '', component: CourseScheduleAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseScheduleAddRoutingModule { }
