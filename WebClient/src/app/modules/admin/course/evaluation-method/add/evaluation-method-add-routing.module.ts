import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EvaluationMethodAddComponent } from './evaluation-method-add.component';

const routes: Routes = [
  { path: '', component: EvaluationMethodAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EvaluationMethodAddRoutingModule { }
