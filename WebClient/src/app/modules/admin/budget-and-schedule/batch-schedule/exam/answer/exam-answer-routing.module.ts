import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExamAnswerComponent } from './exam-answer.component';

const routes: Routes = [
  { path: '', component: ExamAnswerComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExamAnswerRoutingModule { }
