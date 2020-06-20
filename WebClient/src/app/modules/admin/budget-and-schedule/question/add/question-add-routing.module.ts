import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuestionAddComponent } from './question-add.component';

const routes: Routes = [
  { path: '', component: QuestionAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuestionAddRoutingModule { }
