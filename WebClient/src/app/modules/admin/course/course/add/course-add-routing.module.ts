import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CourseAddComponent } from './course-add.component';

const routes: Routes = [
  { path: '', component: CourseAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseAddRoutingModule { }
