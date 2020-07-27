import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyExamStartComponent } from './my-exam-start.component';

const routes: Routes = [
  { path: '', component: MyExamStartComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyExamStartRoutingModule { }
