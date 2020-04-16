import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SubjectAddComponent } from './subject-add.component';

const routes: Routes = [
  { path: '', component: SubjectAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SubjectAddRoutingModule { }
