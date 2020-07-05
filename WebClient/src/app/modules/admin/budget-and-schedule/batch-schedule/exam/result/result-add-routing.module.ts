import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ResultAddComponent } from './result-add.component';

const routes: Routes = [
  { path: '', component: ResultAddComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResultAddRoutingModule { }
