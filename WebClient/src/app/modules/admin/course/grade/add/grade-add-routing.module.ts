import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GradeAddComponent } from './grade-add.component';

const routes: Routes = [
  { path: '', component: GradeAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GradeAddRoutingModule { }
